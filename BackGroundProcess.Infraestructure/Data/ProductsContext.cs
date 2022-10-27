using BackGroundProcess.Application.Data;
using BackGroundProcess.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGroundProcess.Infraestructure.Data
{
    public class ProductsContext : DbContext, IProductsContext
    {
        public ProductsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
        }
    }
}
