using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebShop.Data;
using WebShop.Helpers;
using WebShop.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using WebShop.PayPalHelpers;
namespace WebShop.Controllers
{
    public class CheckoutController : Controller
    {
        public IConfiguration configuration {get;}
        
        private readonly ILogger<CheckoutController> _logger;

        private readonly Webshopdbcontext _context;

        
        public CheckoutController(ILogger<CheckoutController> logger,Webshopdbcontext context,IConfiguration _configuration)
        {
            configuration = _configuration;
            _logger = logger;
            _context = context;
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
        public async Task<IActionResult> Index()
        {
            //menu
            var type = await _context.Type.ToListAsync();
            var cate = await _context.Category.ToListAsync();
            ViewBag.type = type;
            ViewBag.cate= cate;
            wish();
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
            
            if(HttpContext.Session.GetInt32("idUser")!= null){
                 var customers = from s in _context.Customer
                    select s; 
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    ViewBag.cuslogin= cus;
            }
            
            return View();
        }
        public async Task<IActionResult> sucsess()
        {
            HttpContext.Session.SetString("success","success");
            return RedirectToAction("Save");
        }
        public async Task<IActionResult> cancel()
        {
            HttpContext.Session.SetString("success","cancel");
            return RedirectToAction("Save");
        }
        public async Task<IActionResult> Save()
        {   
            if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                if(HttpContext.Session.GetString("success") == null){
                string url="";
                //paypal
                var payPalAPI = new PayPalAPI(configuration);
                var totala = Request.Form["total"][0];
                double total2 = Int32.Parse(totala)/23139  + Int32.Parse(totala)%23139;
                url = await payPalAPI.getRedirectUrlToPayPal(total2, "USD");
                //adddatabase
                var Address = Request.Form["Address"][0];
                 HttpContext.Session.SetString("Address",Address);
                var City = Request.Form["City"][0];
                 HttpContext.Session.SetString("City",City);
                var County = Request.Form["County"][0];
                 HttpContext.Session.SetString("County",County);
                var Postcode = Request.Form["Postcode"][0];
                HttpContext.Session.SetString("Postcode",Postcode);
                var Odernote = Request.Form["Odernote"][0];
                HttpContext.Session.SetString("Odernote",Odernote);
                var total = Request.Form["total"][0];
                HttpContext.Session.SetString("total",total);
                var Id = Request.Form["Id"][0];
                HttpContext.Session.SetString("Id",Id);
                var count = Request.Form["count"][0];
                HttpContext.Session.SetString("count",count);
                return Redirect(url);
            }
            }
            if(HttpContext.Session.GetString("success") == "success"){
                //adddatabase
                var Address = HttpContext.Session.GetString("Address");
                var City = HttpContext.Session.GetString("City");
                var County = HttpContext.Session.GetString("County");
                var Postcode = HttpContext.Session.GetString("Postcode");
                var Odernote = HttpContext.Session.GetString("Odernote");
                var total = HttpContext.Session.GetString("total");
                var Id = HttpContext.Session.GetString("Id");
                var count = HttpContext.Session.GetString("count");
                
                Invoice invoice = new Invoice();
                invoice.Customer_Id = Int32.Parse(Id);
                invoice.customer = _context.Customer.FirstOrDefault(s => s.Id == Int32.Parse(Id));
                invoice.TotalMoney = total;
                invoice.Postcode = Postcode; 
                invoice.amount = count; 
                invoice.CustomerAddress = Address+","+City+","+County;
                invoice.CreateDay = DateTime.Now;
                invoice.Ordernote = Odernote;
                invoice.status="Đang giao hàng";
                _context.Invoice.Add(invoice);
                await _context.SaveChangesAsync();
                //detail
                InvoiceDetail invoiceDetail = new InvoiceDetail();
                var jsoncart="";
                var jsoncartcombo="";
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                if(cart != null){
                    jsoncart = JsonConvert.SerializeObject(cart);
                    invoiceDetail.Products = jsoncart;
                }
                List<ItemCombo> cartcombo = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
                if(cartcombo != null){
                    jsoncartcombo = JsonConvert.SerializeObject(cartcombo);
                    invoiceDetail.Combos = jsoncartcombo;
                }
                var invoices = from s in _context.Invoice
                   select s;
                invoices =  invoices.OrderByDescending(s => s.Id);
                Invoice  a = invoices.First();
                invoiceDetail.Invoice_Id =a.Id;
                _context.InvoiceDetail.Add(invoiceDetail);  
                await _context.SaveChangesAsync();

                //amount
                if(cart!=null){
                    foreach(var item in cart){
                        var products = from s in _context.Product
                        select s;
                        products = products.Where(s => s.Id == item.Product.Id);
                        Product pro = products.FirstOrDefault();
                        pro.Amount = pro.Amount - item.Quantity;
                        await _context.SaveChangesAsync();
                        Removecart(item.Product.Id);
                    }
                }
                if(cartcombo != null){
                    foreach(var item in cartcombo){
                        var cartcombos = from s in _context.Combo
                    select s;
                        cartcombos = cartcombos.Where(s => s.Id == item.Combo.Id);
                        Combo cobo = cartcombos.First();
                        var list = await _context.ComboProduct.Include("Products")
                        .Where(s => s.Combo_Id == cobo.Id).ToListAsync();
                        foreach(var item1 in list){
                        item1.Products.Amount = item1.Products.Amount - item.Quantity;
                        }
                        await _context.SaveChangesAsync();
                        Removecombo(item.Combo.Id);
                    }  
                }
            }
            if(HttpContext.Session.GetString("success") == "cancel"){
                return Redirect("/Checkout");
            }
            return Redirect("/Product");

        } 
        public ActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data =_context.Customer.Where(s => s.UserName.Equals(username) && s.PassWord.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    var customers = data.First();
                    if(customers.status == "Block"){
                        HttpContext.Session.SetString("Block","Block");
                        return Redirect("/Checkout");
                    }
                    //add session
                    HttpContext.Session.SetString("FullName", data.FirstOrDefault().FirstName +" "+ data.FirstOrDefault().LastName);
                    HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                    HttpContext.Session.SetInt32("idUser", data.FirstOrDefault().Id);
                    return Redirect("/Checkout");
                }
                else
                {
                    HttpContext.Session.SetString("loginfail","Login failed");                  
                }
            }
            return Redirect("/Checkout");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
 
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
                
            }
            return byte2String;
        }
        public IActionResult Removecart(int? id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExistcart(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Cart");
        }
        public IActionResult Removecombo(int? id)
        {
            List<ItemCombo> cart = SessionCombo.GetObjectFromJsonCombo<List<ItemCombo>>(HttpContext.Session, "cartcombo");
            int index = isExistcombo(id);
            cart.RemoveAt(index);
            SessionCombo.SetObjectAsJsonCombo(HttpContext.Session, "cartcombo", cart);
            return RedirectToAction("");
        }
        private int isExistcart(int? id)
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
        private int isExistcombo(int? id)
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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
