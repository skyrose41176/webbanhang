using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebShop.Data;
using WebShop.Helpers;
using WebShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

       private readonly Webshopdbcontext _context;

        
        public LoginController(ILogger<LoginController> logger,Webshopdbcontext context)
        {
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
        public async Task<IActionResult> Index()
        {   
            if(HttpContext.Session.GetString("idUser") == null){
                var type = await _context.Type.ToListAsync();
                var cate = await _context.Category.ToListAsync();
                ViewBag.type = type;
                ViewBag.cate= cate;
                wish();
                check();
                return View();
            }else{

                return Redirect("/Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                    var check = _context.Customer.FirstOrDefault(s => s.Email == customer.Email);
                    if (check == null)
                    { 
                        customer.PassWord = GetMD5(customer.PassWord);
                        customer.JoinDate= DateTime.Now;
                        customer.isNew= true;
                        customer.status= "open";
                        _context.Customer.Add(customer);
                        await _context.SaveChangesAsync();
                        //add session
                        HttpContext.Session.SetString("FullName", customer.FirstName +" "+ customer.LastName);
                        HttpContext.Session.SetString("Email", customer.Email);
                        HttpContext.Session.SetInt32("idUser", customer.Id);
                        return Redirect("/Home");
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                    }
            }
            return Redirect("/Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username,string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data =_context.Customer.Where(s => s.UserName.Equals(username) && s.PassWord.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    var customers = from s in _context.Customer
                    select s; 
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser") );
                    if(cus.status == "Block"){
                        HttpContext.Session.SetString("Block","Block");
                        return View();
                    }
                    ViewBag.cus = cus;
                    HttpContext.Session.Remove("loginfail");
                    //add session
                    HttpContext.Session.SetString("FullName", data.FirstOrDefault().FirstName +" "+ data.FirstOrDefault().LastName);
                    HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                    HttpContext.Session.SetInt32("idUser", data.FirstOrDefault().Id);
                    return Redirect("/Home");
                }
                else
                {
                    HttpContext.Session.SetString("loginfail","Login failed");                  
                }
            }
            return Redirect("/Login");
        }
        
        public async Task<IActionResult> Account()
        {
             if(HttpContext.Session.GetInt32("idUser") != null){
                var type = await _context.Type.ToListAsync();
                var cate = await _context.Category.ToListAsync();
                ViewBag.type = type;
                ViewBag.cate= cate;
                wish();
                check();
                var customers = from s in _context.Customer
                   select s; 
                var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser") );
                ViewBag.cus = cus;
                return View();
            }else{
                return Redirect("/Home");
            }
        }
        //edit
        public async Task<IActionResult> Edit(string id)
        {
             if(HttpContext.Session.GetString("idUser") != null){
                var type = await _context.Type.ToListAsync();
                var cate = await _context.Category.ToListAsync();
                ViewBag.type = type;
                ViewBag.cate= cate;
                wish();
                check();
                ViewBag.validate="The field Email must match the regular expression '[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}'.";
                ViewBag.validate1="[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,4}";
                var customers = from s in _context.Customer
                   select s; 
                var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser") );
                ViewBag.cus = cus;
                if(id=="UserName"){
                    HttpContext.Session.SetString("User","1");
                }
                if(id=="FirstName"){
                    HttpContext.Session.SetString("User","2");
                }
                if(id=="LastName"){
                    HttpContext.Session.SetString("User","3");
                }
                if(id=="Email"){
                    HttpContext.Session.SetString("User","4");
                }
                if(id=="Phone"){
                    HttpContext.Session.SetString("User","5");
                }
                if(id=="Birthdate"){
                    HttpContext.Session.SetString("User","6");
                }
                if(id=="Gender"){
                    HttpContext.Session.SetString("User","7");
                }
                if(id=="Address"){
                    HttpContext.Session.SetString("User","8");
                }
                if(id=="Password"){
                    HttpContext.Session.SetString("User","9");
                }
                if(id=="History"){
                    HttpContext.Session.Remove("details");
                    HttpContext.Session.SetString("User","10");
                    var invoice = _context.Invoice.Where(s => s.Customer_Id == HttpContext.Session.GetInt32("idUser")).OrderByDescending(s =>s.CreateDay);
                    if (invoice == null )
                    { 
                        HttpContext.Session.SetString("invoice",null);
                    }
                    else
                    {
                        ViewBag.invoice= invoice;
                        HttpContext.Session.SetString("invoice","access");
                    }
                }else{
                    var details = _context.InvoiceDetail.FirstOrDefault(s => s.Invoice_Id == Int32.Parse(id));
                    Item[] cart=null;
                    ItemCombo[] cartcombo=null;
                    if(details.Products != null){
                        cart = JsonConvert.DeserializeObject<Item[]>(details.Products);
                    }
                    if(details.Combos != null){
                        cartcombo = JsonConvert.DeserializeObject<ItemCombo[]>(details.Combos);
                    }
                    var a= cart[0].Product;
                    HttpContext.Session.SetString("details","access");
                    ViewBag.cart=cart;
                    ViewBag.cartcombo=cartcombo;
                }
                return View();
            }else{
                return Redirect("/Home");
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Customer customer)
        {
            HttpContext.Session.Remove("Editfail");
                if(HttpContext.Session.GetString("User")=="1")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.UserName == customer.UserName);
                    if (check == null )
                    { 
                        cus.UserName= customer.UserName;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                    if(check.UserName == cus.UserName){
                        HttpContext.Session.SetString("Editfail","Change your UserName");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Editfail","UserName already exists");
                        return Redirect("/Login/Edit");
                    }
                    
                }
                if(HttpContext.Session.GetString("User")=="2")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.FirstName == customer.FirstName);
                    if(customer.FirstName == cus.FirstName){
                        HttpContext.Session.SetString("Editfail","Change your FirstName");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        cus.FirstName= customer.FirstName;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    } 
                }
                if(HttpContext.Session.GetString("User")=="3")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.LastName == customer.LastName);
                    if(customer.LastName == cus.LastName){
                        HttpContext.Session.SetString("Editfail","Change your LastName");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        cus.LastName= customer.LastName;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                }
                if(HttpContext.Session.GetString("User")=="4")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.Email == customer.Email);
                    if (check == null )
                    { 
                        cus.Email= customer.Email;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                    if(check.Email == cus.Email){
                        HttpContext.Session.SetString("Editfail","Change your Email");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Editfail","Email already exists");
                        return Redirect("/Login/Edit");
                    }
                    
                }
                if(HttpContext.Session.GetString("User")=="5")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.Phone == customer.Phone);
                    if(customer.Phone == cus.Phone){
                        HttpContext.Session.SetString("Editfail","Change your Phone");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        cus.Phone= customer.Phone;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                }
                if(HttpContext.Session.GetString("User")=="6")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.Birthdate == customer.Birthdate);
                    if(customer.Birthdate == cus.Birthdate){
                        HttpContext.Session.SetString("Editfail","Change your Birthdate");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                    cus.Birthdate= customer.Birthdate;
                    await _context.SaveChangesAsync();
                    return Redirect("/Login/Edit");
                    }
                }
                if(HttpContext.Session.GetString("User")=="7")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    cus.Gender= customer.Gender;
                    await _context.SaveChangesAsync();
                    return Redirect("/Login/Edit");
                }
                if(HttpContext.Session.GetString("User")=="8")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var check = _context.Customer.FirstOrDefault(s => s.Address == customer.Address);
                    if(customer.Address == cus.Address){
                        HttpContext.Session.SetString("Editfail","Change your Address");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        cus.Address= customer.Address;
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                }
                if(HttpContext.Session.GetString("User")=="9")
                {
                    var cus = _context.Customer.FirstOrDefault(s => s.Id == HttpContext.Session.GetInt32("idUser"));
                    var oldpass="";
                    if(Request.HasFormContentType && Request.Form != null && Request.Form.Count() > 0){
                        oldpass = Request.Form["OldPassWord"][0];
                    } 
                    var pass= GetMD5(oldpass);
                    var check = _context.Customer.FirstOrDefault(s => s.PassWord == pass && s.Id == HttpContext.Session.GetInt32("idUser") );
                    if (check == null )
                    { 
                        HttpContext.Session.SetString("Editfail","Wrong old password");
                        return Redirect("/Login/Edit");
                    }
                    else
                    {
                        cus.PassWord= GetMD5(customer.PassWord);
                        await _context.SaveChangesAsync();
                        return Redirect("/Login/Edit");
                    }
                    
                }
                
                
            
            return Redirect("/Login/Edit");
        }
        
        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("idUser");//remove session
            return Redirect("/Home");
        }

        public ActionResult Back()
        {
            HttpContext.Session.Remove("Editfail");
            return Redirect("/Login/Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

    }
}
