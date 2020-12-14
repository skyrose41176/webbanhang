using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebShop.Data;
using WebShop.Helpers;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Webshopdbcontext _context;
        public HomeController(ILogger<HomeController> logger,Webshopdbcontext context)
        {
            _logger = logger;
            _context = context;
        }
        public void cart(){
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
                 ViewBag.totalwish =0;
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
        public async Task<IActionResult> Index()
        {
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            cart();
            wish();
            var newproduct = await _context.Product
                    .Where(s => s.Amount >= 97 && s.Amount >= 50 && s.Category_ID == 1)
                    .ToListAsync();
            var bestseller = await _context.Product
                    .Where(s => s.Amount < 50 && s.Amount >= 20 && s.Category_ID == 1)
                    .ToListAsync();
            var featured = await _context.Product
                    .Where(s => s.Amount < 20 && s.Category_ID == 1)
                    .ToListAsync(); 
            ViewBag.newproduct = newproduct;
            ViewBag.bestseller = bestseller;
            ViewBag.featured = featured;
            var GoodPrice = await _context.Product 
                    .Where(s => s.Price <= 10000000)
                    .ToListAsync(); 
            ViewBag.GoodPrice = GoodPrice;
            var New = await _context.Product
                    .Where(s => s.Price > 10000000)
                    .ToListAsync();
            ViewBag.New = New;

            return View();  
        }
        public async Task<IActionResult> About()
        {
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            cart();
            wish();
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            cart();
            wish();
            return View();
        }
        public async Task<IActionResult> FAQ()
        {
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            cart();
            wish();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;   
            cart();  
            wish(); 
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
