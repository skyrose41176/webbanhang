using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Category Name")]
        [StringLength(35)]
        public string CategoryName{ get;set; }
        public int Type_Id{ get;set; }  
        public Type Type{ get;set; }  

        [ForeignKey("Category_ID")]
        public ICollection<Product> Products { get; set; }
    }
}
