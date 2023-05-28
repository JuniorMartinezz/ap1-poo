using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap2_poo.Domain;
using aula12_ef_test.Domain;
using Microsoft.EntityFrameworkCore;
using poo_ap1;

namespace ap1_poo.Data.Repositories
{
    public class DataContext : DbContext
    {
        public string DbPath { get; }
        
        public DataContext() {
            string path = Directory.GetCurrentDirectory();
            DbPath = System.IO.Path.Join(path, "ap2-schema.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Buy> Buys { get; set; }
    }
}
