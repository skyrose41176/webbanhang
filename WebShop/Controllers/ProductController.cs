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
    public class ProductController : Controller
    {
        private readonly Webshopdbcontext _context;

        public ProductController(Webshopdbcontext context)
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
        // GET: Product
        public async Task<IActionResult> Index(string Sort,string currentFilter,string Search, int? page,string Price,string Cate,string catesearch)           
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
                ViewBag.CurrentCate = "";
            }
            else{
            //cate
            ViewBag.CurrentCate = Cate;
            foreach(var item in type){
                foreach (var item1 in cate)
                {
                    if(item.Id == item1.Type_Id){
                        if(Cate == item1.CategoryName ){
                            ViewBag.catepro = item1.CategoryName;
                            ViewBag.cateid = item1.Id;
                            break;
                        }
                        if(Cate == null){
                            ViewBag.catepro = String.IsNullOrEmpty(Cate) ? (string)item1.CategoryName : "";
                            ViewBag.cateid = null;
                            break;
                        }
                    }
                }                
            }
            //price
            ViewBag.CurrentPrice = Price;
            ViewBag.PriceProduct = (Price == "1M - 2M" || Price == "2M - 3M" || Price == "3M - 5M" || Price == "5M - 10M" || Price == "10M - 15M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "0 - 1M" : "";
            ViewBag.PriceProduct1 = (Price == "0 - 1M" || Price == "2M - 3M" || Price == "3M - 5M" || Price == "5M - 10M" || Price == "10M - 15M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "1M - 2M" : "";
            ViewBag.PriceProduct2 = (Price == "1M - 2M" || Price == "0 - 1M" || Price == "3M - 5M" || Price == "5M - 10M" || Price == "10M - 15M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "2M - 3M" : "";
            ViewBag.PriceProduct3 = (Price == "1M - 2M" || Price == "2M - 3M" || Price == "0 - 1M" || Price == "5M - 10M" || Price == "10M - 15M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "3M - 5M" : "";
            ViewBag.PriceProduct4 = (Price == "1M - 2M" || Price == "2M - 3M" || Price == "3M - 5M" || Price == "0 - 1M" || Price == "10M - 15M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "5M - 10M" : "";
            ViewBag.PriceProduct5 = (Price == "1M - 2M" || Price == "2M - 3M" || Price == "3M - 5M" || Price == "5M - 10M" || Price == "0 - 1M" || Price == "15M >>" || String.IsNullOrEmpty(Price) ) ? "10M - 15M" : ""; 
            ViewBag.PriceProduct6 = (Price == "1M - 2M" || Price == "2M - 3M" || Price == "3M - 5M" || Price == "5M - 10M" || Price == "10M - 15M" || Price == "0 - 1M" || String.IsNullOrEmpty(Price) ) ? "15M >>" : ""; 
            }
            //product
            ViewBag.CurrentSort = Sort;
            ViewBag.NameSortParm = (Sort == "name_asc" || Sort == "Price_asc" || Sort == "Price_desc" || String.IsNullOrEmpty(Sort) ) ? "name_desc" : "";
            ViewBag.NameSortParm1 = (Sort == "name_desc" || Sort == "Price_asc" || Sort == "Price_desc" || String.IsNullOrEmpty(Sort) ) ? "name_asc" : "";
            ViewBag.PriceSortParm = (Sort == "Price_asc" || Sort == "name_desc" || Sort == "name_asc"  || String.IsNullOrEmpty(Sort) ) ? "Price_desc" : "";
            ViewBag.PriceSortParm1 = (Sort == "Price_desc" || Sort == "name_desc" || Sort == "name_asc"  || String.IsNullOrEmpty(Sort) ) ? "Price_asc" : "";
            ViewBag.Currentcatesearch = catesearch;
            if(catesearch == null){
                catesearch = "ALL";
            }
            if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                catesearch = Request.Form["catesearch"][0];
                ViewBag.Currentcatesearch = catesearch;
            }
            if (Search != null)
            {
                page = 1;
            }
            else
            {
                Search = currentFilter;
            }
            
            ViewBag.CurrentFilter = Search;
            
            var products = from s in _context.Product
                   select s; 
            if(catesearch != "ALL"){
                if(!String.IsNullOrEmpty(Search))
                {
                    products =  products.Where(s => s.Productname.Contains(Search) && s.Category_ID == Int16.Parse(catesearch));                         
                }else{
                    products =  products.Where(s =>s.Category_ID == Int16.Parse(catesearch)); 
                }
            }else{
                if(!String.IsNullOrEmpty(Search))
                {
                products =  products.Where(s => s.Productname.Contains(Search)); 
                }
            } 

            switch (Price)
            {
                case "0 - 1M":
                    products =  products.Where(s => s.Price <= 1000000 );                  
                    break;
                case "1M - 2M":
                    products =  products.Where(s => s.Price > 1000000 && s.Price <= 2000000 );              
                    break;
                case "2M - 3M":
                    products =  products.Where(s => s.Price > 2000000 && s.Price <= 3000000);                  
                    break;
                case "3M - 5M":
                    products =  products.Where(s => s.Price < 3000000 && s.Price <= 5000000);                 
                    break;
                case "5M - 10M":
                    products =  products.Where(s => s.Price > 5000000 && s.Price <= 10000000);                 
                    break;
                case "10M - 15M":
                    products =  products.Where(s => s.Price > 10000000 && s.Price <= 15000000);              
                    break;
                case "15M >>":
                    products =  products.Where(s => s.Price > 15000000 );                  
                    break;
                default:
                    products =  products.Where(s => s.Price > 0 );
                    break;
            }
            //cate
            foreach(var item in type){
                foreach (var item1 in cate)
                {
                    if(ViewBag.cateid != null){
                        if(item1.Id == ViewBag.cateid){
                            products = products.Where(s => s.Category_ID == item1.Id );
                        }
                    } 
                }                
            } 
            switch (Sort)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Productname);                  
                    break;
                case "name_asc":
                    products = products
                    .OrderBy(s => s.Productname);
                break;
                case "Price_asc":
                    products = products
                    .OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    products = products
                    .OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products
                    .OrderBy(s => s.Productname);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(products.ToList().ToPagedList(pageNumber, pageSize));
        }
        public async Task<IActionResult> Cart()
        {
             //menu
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            check();
            wish();
            ViewBag.cbpro = await _context.ComboProduct.ToListAsync();
            return View();
        }

        public async Task<IActionResult>  AddtoCart(int? id)
        {
            
            var products = from s in _context.Product
                   select s;
            var qty="1";
            if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                qty = Request.Form["quatity"][0];
            }      
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                var list = await _context.Product
                .Where(s => s.Id == id).FirstAsync();
                list.Amount = list.Amount - Int16.Parse(qty);
                await _context.SaveChangesAsync();
                cart.Add(new Item { Product = products.First(s => s.Id == id), Quantity = Int16.Parse(qty)});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var list = await _context.Product
                .Where(s => s.Id == id).FirstAsync();
                list.Amount = list.Amount - Int16.Parse(qty);
                await _context.SaveChangesAsync();
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity+=Int16.Parse(qty);
                }
                else
                {
                    cart.Add(new Item { Product = products.First(s => s.Id == id), Quantity = Int16.Parse(qty)});
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("");
        }
         public async Task<IActionResult> Remove(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            var list = await _context.Product
                .Where(s => s.Id == id).FirstAsync();
            list.Amount = list.Amount + cart[index].Quantity  ;
            await _context.SaveChangesAsync();
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Cart");
        }
        public IActionResult Removex(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("");
        }
         
        private int isExist(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        //update
        public IActionResult Update()
        {
            check();
            if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                var list = Request.Form["product[]"];
                for(var i = 0;i < list.Count;i++){   
                    List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");                
                    cart[i].Quantity = Int16.Parse(list[i]);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                var listcombo = Request.Form["combo[]"];
                for(var i = 0;i< listcombo.Count;i++){
                    List<ItemCombo> cartcombo = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
                    cartcombo[i].Quantity = Int16.Parse(listcombo[i]);
                    SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cartcombo);
                }
            }
            return RedirectToAction("");
        }
        // GET: Product/Details/5
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

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            var list = await _context.Product
                .Where(m => m.Category_ID == product.Category_ID)
                .ToListAsync();
            ViewBag.product = product;
            ViewBag.list= list;
            check();
            wish();
            return View();
        }
        //wishlist
        public void wish(){
            //wish
            var wish = SessionWish.GetObjectFromJsonWish<List<Item>>(HttpContext.Session, "wish");
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
        public IActionResult AddtoWish(int? id)
        {
            var products = from s in _context.Product
                   select s; 
            if (SessionWish.GetObjectFromJsonWish<List<Item>>(HttpContext.Session, "wish") == null)
            {
                List<Item> wish = new List<Item>();
                wish.Add(new Item { Product = products.First(s => s.Id == id), Quantity = 1 });
                SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wish", wish);
            }
            else
            {
                List<Item> wish = SessionWish.GetObjectFromJsonWish<List<Item>>(HttpContext.Session, "wish");
                int index = isExistwish(id);
                if (index != -1)
                {
                    wish[index].Quantity = 1;
                }
                else
                {
                    wish.Add(new Item { Product = products.First(s => s.Id == id), Quantity = 1 });
                }
                SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wish", wish);
            }
            return RedirectToAction("");
        }
         public IActionResult Removewish(int? id)
        {
            List<Item> wish = SessionWish.GetObjectFromJsonWish<List<Item>>(HttpContext.Session, "wish");
            int index = isExistwish(id);
            wish.RemoveAt(index);
            SessionWish.SetObjectAsJsonWish(HttpContext.Session, "wish", wish);
            return RedirectToAction("wishlist");
        }
        private int isExistwish(int? id)
        {
            List<Item> wish = SessionWish.GetObjectFromJsonWish<List<Item>>(HttpContext.Session, "wish");
            for (int i = 0; i < wish.Count; i++)
            {
                if (wish[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }

}
