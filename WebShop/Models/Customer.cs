using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 4)]
        public string UserName{ get;set; }
        [Required]
        [StringLength(1000, MinimumLength = 6)]   
        public string PassWord{ get;set; } 
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [StringLength(1000)]   
        public string Email {get;set;}
        [Required]
        [DisplayName("FirstName")]
        [StringLength(35, MinimumLength = 6)]   
        public string FirstName{ get;set; } 
        [Required]  
        [DisplayName("LastName")]
        [StringLength(1000, MinimumLength = 6)]   
        public string LastName{ get;set; }   
        [Required]
        [DisplayName("Gender")]
        [StringLength(1000)]   
        public string Gender{ get;set; } 
        [Required]  
        [DisplayName("Birthdate")]  
        public DateTime Birthdate{ get;set; }  
        [Required]  
        [DisplayName("Address")]
        [StringLength(1000, MinimumLength = 3)]   
        public string Address{ get;set; }
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Phone{ get;set; }        
        public DateTime JoinDate{ get;set; }     
        public Boolean isNew{ get;set; }  
        public string status{ get;set; } 

        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("PassWord")]
        public string ConfirmPassword { get; set; }
        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }

        [ForeignKey("Customer_Id")]
        public ICollection<Invoice> Invoice { get; set; }
        
    }
}
