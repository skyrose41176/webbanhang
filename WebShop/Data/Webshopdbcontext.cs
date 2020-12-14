using Microsoft.EntityFrameworkCore;
using WebShop.Models;
namespace WebShop.Data
{
    public class Webshopdbcontext : DbContext
    {
        public Webshopdbcontext()
        {
        }

        public Webshopdbcontext (DbContextOptions<Webshopdbcontext> options)
            : base(options)
        {
        }      
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Combo> Combo { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Emplopyee { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Type> Type { get; set; }        
        public DbSet<ComboProduct> ComboProduct { get; set; }
    
    }
}