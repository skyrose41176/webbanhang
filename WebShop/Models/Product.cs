using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Productname")]
        [StringLength(1000)]
        public string Productname{ get;set; }  
        public int Category_ID{ get;set; }  
        public Category Category{ get;set; }  

        [DisplayName("Amount")]
        public int? Amount{ get;set; }    
        [DisplayName("Price")]
        public int? Price{ get;set; }
        [DisplayName("Details")]
        [StringLength(1000)]
        public string Detail{ get;set; }    
        [StringLength(1000)]
        public string Image{ get;set; } 
        [ForeignKey("Product_Id")]
        public List<ComboProduct> ComboProducts { get;set; }       

        //[ForeignKey("Product_Id")]
        //public ICollection<InvoiceDetail> InvoiceDetails { get; set; } 
    }
}
