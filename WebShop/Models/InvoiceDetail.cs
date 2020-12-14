using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebShop.Data;
namespace WebShop.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        public int Invoice_Id { get; set; }
        public Invoice Invoice{ get; set; }   
        public string Products{ get;set; } 
        public string Combos{ get;set;}
    }
}
