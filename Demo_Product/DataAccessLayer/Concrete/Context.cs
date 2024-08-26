using Entity_Layer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LICHSAN\\KAANEXPRESS;database=DbDemo;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet <Customer> Customers { get; set; }

        public DbSet <Category> Categories { get; set; }
    }
}
