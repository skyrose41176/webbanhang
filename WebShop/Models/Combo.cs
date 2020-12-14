using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class Combo
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("ComboName")]
        [StringLength(1000)]
        public string ComboName{ get;set; }
        [ForeignKey("Combo_Id")]
        public List<ComboProduct> ComboProducts { get;set; }   
        public DateTime DayStart{ get;set; }    
        public DateTime DayEnd{ get;set; }    
        public int Total{ get;set; }   
        [StringLength(1000)]
        public string Discount{ get;set; }  
        [StringLength(1000)]  
        public string DiscountMoney{ get;set; }      
        public string Image{get;set;}
        
    }
}
