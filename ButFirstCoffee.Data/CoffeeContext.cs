using ButFirstCoffee.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButFirstCoffee.Data
{
    public class CoffeeContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<BeverageCategory> BeverageCategories { get; set; }
        public DbSet<BeverageSale> BeverageSales { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Condiment> Condiments { get; set; }

        public CoffeeContext(DbContextOptions<CoffeeContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeverageSale>()
                .HasKey(b => new { b.BeverageId, b.SaleId });
        }
    }
}
