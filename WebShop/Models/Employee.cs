using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserName{ get;set; }   
        public string PassWord{ get;set; }    
        public string FirstName{ get;set; }     
        public string LastName{ get;set; }    
        public string Gender{ get;set; }   
        public DateTime Birthdate{ get;set; }    
        public string Address{ get;set; }    
        public DateTime JoinDate{ get;set; }    
        public string Role{ get;set; } 
        public string status{ get;set; } 
   
    }
}
