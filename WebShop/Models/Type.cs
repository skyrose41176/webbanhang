using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        
        [DisplayName("Type Name")]
        [StringLength(35)]
        public string TypeName{ get;set; } 
        
        [ForeignKey("Type_Id")]
        public ICollection<Category> Categorys { get; set; }
    }
}
