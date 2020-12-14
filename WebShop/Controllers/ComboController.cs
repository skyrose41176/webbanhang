using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using WebShop.Data;
using WebShop.Models;
using WebShop.Helpers;

namespace WebShop.Controllers
{
    public class ComboController : Controller
    {
        private readonly Webshopdbcontext _context;

        public ComboController(Webshopdbcontext context)
        {
            _context = context;
        }
        public void check(){
            //cart
            var count=0;
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if(cart != null){
            ViewBag.cart = cart;
            var total =  cart.Sum(item => item.Product.Price * item.Quantity);
            count = count + cart.Sum(item => item.Quantity);
            ViewBag.count=count;
            ViewBag.total = total;
            if(total > 0)
            ViewBag.totalm = total/1000000 + "M" ;
            else{
            ViewBag.totalm = 0;
            }
            }else{
                List<Item> cart1 = new List<Item>();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart1);
                ViewBag.cart = cart1;
                ViewBag.count = 0;
                ViewBag.total = 0;     
                ViewBag.totalm = 0;  
            }
            //combo
            var countcombo=ViewBag.count;
            var cartcombo = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
            if(cartcombo != null){
            ViewBag.cartcombo = cartcombo;
            var combototal =  ViewBag.total + cartcombo.Sum(item => item.Combo.Total * item.Quantity);
            countcombo = countcombo + cartcombo.Sum(item => item.Quantity);
            ViewBag.count = countcombo;
            ViewBag.total = combototal;
            if(combototal > 0)
            ViewBag.totalm = combototal/1000000 + "M" ;
            else{
            ViewBag.totalm = 0;
            }
            }else{
                List<ItemCombo> cart1 = new List<ItemCombo>();
                SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cart1);
                ViewBag.cartcombo = cart1;
                ViewBag.count = 0;
                ViewBag.total = 0;     
                ViewBag.totalm = 0;  
            }
        }
        public async Task<IActionResult> Index(string Sort,string currentFilter, int? page,string Price)           
        {
           
            check();
            wish();
            //menu
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            //filter
            var asd = await _context.Type.ToListAsync();
            var brand = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            //price
            if(Price == "Clear"){
                ViewBag.CurrentPrice = "";
            }
            else{
            //price
            ViewBag.CurrentPrice = Price;
            ViewBag.PriceProduct = (Price == "10M - 20M" || Price == "20M >>" || String.IsNullOrEmpty(Price) ) ? "0 - 10M" : "";
            ViewBag.PriceProduct1 = (Price == "0 - 10M" || Price == "20M >>"  || String.IsNullOrEmpty(Price) ) ? "10M - 20M" : "";
            ViewBag.PriceProduct2 = (Price == "0M - 10M" || Price == "10M - 20M"  || String.IsNullOrEmpty(Price) ) ? "20M >>" : "";
            }
            //product
            ViewBag.CurrentSort = Sort;
            ViewBag.NameSortParm = (Sort == "name_asc" || Sort == "Price_asc" || Sort == "Price_desc" || String.IsNullOrEmpty(Sort) ) ? "name_desc" : "";
            ViewBag.NameSortParm1 = (Sort == "name_desc" || Sort == "Price_asc" || Sort == "Price_desc" || String.IsNullOrEmpty(Sort) ) ? "name_asc" : "";
            ViewBag.PriceSortParm = (Sort == "Price_asc" || Sort == "name_desc" || Sort == "name_asc"  || String.IsNullOrEmpty(Sort) ) ? "Price_desc" : "";
            ViewBag.PriceSortParm1 = (Sort == "Price_desc" || Sort == "name_desc" || Sort == "name_asc"  || String.IsNullOrEmpty(Sort) ) ? "Price_asc" : "";
            
            var combos = from s in _context.Combo
                   select s; 
            switch (Price)
            {
                case "0 - 10M":
                    combos =  combos.Where(s => s.Total <= 10000000 );                  
                    break;
                case "10M - 20M":
                    combos =  combos.Where(s => s.Total > 10000000 && s.Total <= 20000000 );              
                    break;
                case "20M >>":
                    combos =  combos.Where(s => s.Total > 20000000);                  
                    break;              
                default:
                    combos =  combos.Where(s => s.Total > 0 );
                    break;
            }
            switch (Sort)
            {
                case "name_desc":
                    combos = combos.OrderByDescending(s => s.ComboName);                  
                    break;
                case "name_asc":
                    combos = combos
                    .OrderBy(s => s.ComboName);
                break;
                case "Price_asc":
                    combos = combos
                    .OrderBy(s => s.Total);
                    break;
                case "Price_desc":
                    combos = combos
                    .OrderByDescending(s => s.Total);
                    break;
                default:
                    combos = combos
                    .OrderBy(s => s.ComboName);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(combos.ToList().ToPagedList(pageNumber, pageSize));
        }
        public IActionResult AddtoCart(int? id)
        {
            var combos = from s in _context.Combo
                   select s; 
            var qty="1";
            if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                qty = Request.Form["quatity"][0];
            }
            if (SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo") == null)
            {
                List<ItemCombo> cart = new List<ItemCombo>();
                cart.Add(new ItemCombo { Combo = combos.First(s => s.Id == id), Quantity = Int16.Parse(qty) });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ItemCombo> cart = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity+=Int16.Parse(qty);
                }
                else
                {
                    cart.Add(new ItemCombo { Combo = combos.First(s => s.Id == id), Quantity = Int16.Parse(qty) });
                }
                SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cart);
            }
            return RedirectToAction("");
        }
        public IActionResult Remove(int? id)
        {
            List<ItemCombo> cart = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cart);
            return RedirectToAction("");
        }
        public IActionResult Removex(int? id)
        {
            List<ItemCombo> cart = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cart);
            return RedirectToAction("");
        }
        private int isExist(int? id)
        {
            List<ItemCombo> cart = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Combo.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        public async Task<IActionResult> Details(int? id)
        {
             //menu
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            if (id == null)
            {
                return NotFound();
            }

            var combo = await _context.Combo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combo == null)
            {
                return NotFound();
            }
            ViewBag.combo = combo;

            var listcb = await _context.ComboProduct
                .Where(s => s.Combo_Id == id).ToListAsync();
            List<int> a = new List<int>();
            for(var i =0; i< listcb.Count() ;i++){
                a.Add(listcb[i].Product_Id);
            }
            List<Product> product = new List<Product>();
            for(var i = 0; i< a.Count() ;i++){
                var pro = await _context.Product
                .Where(s => s.Id == a[i]).ToListAsync();
                var azxc = pro[0].Amount;
                if(pro[0].Amount == 0){
                    ViewBag.listcb = "0";
                }
            }
            var list = await _context.ComboProduct.Include("Products")
            .Where(s => s.Combo_Id == id).ToListAsync();
            ViewBag.list = list;
            check();
            wish();
            return View();
        }
        //wishlist
        public void wish(){
              //wish
            var wish = SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wish");
            if(wish != null){
                var total =  wish.Sum(item => item.Quantity); 
                ViewBag.totalwish = total;
                ViewBag.wish = wish;
            }else{
                List<Item> wish1 = new List<Item>();
                SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wish", wish1);
                ViewBag.wish = wish1;
                ViewBag.totalwish = 0;
            }
            var count = ViewBag.totalwish;
            var wishcombo = SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wishcombo");
            if(wishcombo != null){
                var total = count +  wishcombo.Sum(item => item.Quantity); 
                ViewBag.totalwish = total;
                ViewBag.wishcombo = wishcombo;
            }else{
                List<ItemCombo> wish1 = new List<ItemCombo>();
                SessionWishCombo.SetObjectAsJsonWishCombo(HttpContext.Session, "wishcombo", wish1);
                ViewBag.wishcombo = wish1;
                ViewBag.totalwish = count;
            }
        }
        public async Task<IActionResult> Wishlist()
        {
             //menu
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            check();
            wish();
            return View();
        }
        public IActionResult AddtoWishCombo(int? id)
        {
            var combos = from s in _context.Combo
                   select s; 
            if (SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wishcombo") == null)
            {
                List<ItemCombo> wish = new List<ItemCombo>();
                wish.Add(new ItemCombo { Combo = combos.First(s => s.Id == id), Quantity = 1 });
                SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wishcombo", wish);
            }
            else
            {
                List<ItemCombo> wish = SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wishcombo");
                int index = isExistwish(id);
                if (index != -1)
                {
                    wish[index].Quantity = 1;
                }
                else
                {
                    wish.Add(new ItemCombo { Combo = combos.First(s => s.Id == id), Quantity = 1 });
                }
                SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wishcombo", wish);
            }
            return RedirectToAction("");
        }
         public IActionResult Removewish(int? id)
        {
            List<ItemCombo> wish = SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wishcombo");
            int index = isExistwish(id);
            wish.RemoveAt(index);
            SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wishcombo", wish);
            return RedirectToAction("");
        }
        private int isExistwish(int? id)
        {
            List<ItemCombo> wish = SessionWishCombo.GetObjectFromJsonWishCombo<List<ItemCombo>>(HttpContext.Session, "wishcombo");
            for (int i = 0; i < wish.Count; i++)
            {
                if (wish[i].Combo.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }

}
