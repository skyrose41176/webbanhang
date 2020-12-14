using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public string Product_Id { get; set; }
        public string Amount{ get;set; }    
        public DateTime importdate{ get;set; } 
        public DateTime exportdate{ get;set; } 
    }
}
