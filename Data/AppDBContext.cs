using System;
using DemoStandardProject.Models.Products;
using DemoStandardProject.Models.Sales;
using Microsoft.EntityFrameworkCore;


namespace DemoStandardProject.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<SalesHeader> SalesHeaders { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public Func<DateTime> Now { get; set; } = () => DateTime.Now;
        public DbSet<ProductStockLog> ProductStockLogs { get; set; }

    }
}