using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopWebApllication.Data.Models;

namespace ShopWebApllication.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
