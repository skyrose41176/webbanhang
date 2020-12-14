using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class ComboProduct
    {
        [Key]
        public int Id { get; set; }
        public int Combo_Id { get; set; }
        public Combo Combos { get; set; }
        public int Product_Id { get; set; }
        public Product Products { get; set; }
    }
}
