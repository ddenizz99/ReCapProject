using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProject;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        //CUSTOM MAPPING
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Urunler");
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("UrunID");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("UrunAdi");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("UrunFiyat");
        }
    }
}
