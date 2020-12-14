using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class ItemCombo
    {
        public Combo Combo { get; set; }
        public int Quantity { get; set; } 

       
    }
}
