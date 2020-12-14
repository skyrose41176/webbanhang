using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; } 
        
    }
}
