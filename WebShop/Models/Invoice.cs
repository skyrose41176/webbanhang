using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebShop.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }  
        public int Customer_Id{ get;set; }  
        public Customer customer{ get;set; } 
        public string TotalMoney{ get;set; }  
        public string amount{ get;set; }  
        public DateTime CreateDay{ get;set; }
        public string Ordernote  { get;set; }
        public string Postcode  { get;set; }
        public string CustomerAddress{ get;set; }
        public string status { get;set;}       

        [ForeignKey("Invoice_Id")]
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; } 

    }
}
