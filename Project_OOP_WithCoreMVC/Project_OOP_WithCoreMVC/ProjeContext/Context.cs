using Microsoft.EntityFrameworkCore;
using Project_OOP_WithCoreMVC.Entity;

namespace Project_OOP_WithCoreMVC.ProjeContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LICHSAN\\KAANEXPRESS;database=DbNewOOPCore;integrated security=true;TrustServerCertificate=true");
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
