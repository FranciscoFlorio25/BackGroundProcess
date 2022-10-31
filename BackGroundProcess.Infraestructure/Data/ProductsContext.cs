using BackGroundProcess.Application.Data;
using BackGroundProcess.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
