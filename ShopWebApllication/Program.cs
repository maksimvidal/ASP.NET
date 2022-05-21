using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopWebApllication.Data;
using ShopWebApllication.Data.Models;

namespace ShopWebApllication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                Furniture f1 = new Furniture
                {
                    id = "3",
                    name = "Кресло1",
                    category = new Category { id = "6", name = "s" },
                    img = "/img/Кресло.jpg",
                    price = 15000,
                    inStock = true
                };
                Furniture f2 = new Furniture
                {
                    id = "4",
                    name = "Кресло2",
                    category = new Category { id = "7", name = "s" },
                    img = "/img/Кресло.jpg",
                    price = 17000,
                    inStock = true
                };
                Purchase p1 = new Purchase
                {
                    id = "11",
                    price = 15000,
                    furnitures = new List<Furniture> { f1, f2 }
                };
                //      db.Furnitures.Add(f1);
                //      db.Furnitures.Add(f2);
                //      db.Purchases.Add(p1);
                //      db.SaveChanges();
                db.Purchases.ToList().ForEach(x => 
                db.Entry(x).State = EntityState.Deleted);
                db.Furnitures.ToList().ForEach(x =>
                db.Entry(x).State = EntityState.Deleted);
                generateFurnitures(db);
                db.SaveChanges();
                db.Database.EnsureCreated();
                db.Furnitures.ToList().ForEach(x =>Console.WriteLine(x.img));
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void generateFurnitures(AppDBContent db) 
        {
            Furniture f1 = new Furniture
            {
                id = "1",
                name = "Office chair",
                category =null,
                img = "https://i.ibb.co/0r2SFXr/3.jpg",
                price = 15000,
                inStock = true
            };
            Furniture f2 = new Furniture
            {
                id = "2",
                name = "Rel. office chair",
                category = null,
                img = "https://i.ibb.co/Zdp3c5N/noblechairs-HERO-Black-Ed-2.jpg",
                price = 17000,
                inStock = true
            };
            Furniture f3 = new Furniture
            {
                id = "3",
                name = "Home chair",
                category = null,
                img = "https://i.ibb.co/V2Pz3LY/image.jpg",
                price = 15000,
                inStock = true
            };
            Furniture f4 = new Furniture
            {
                id = "4",
                name = "Rel. home chair",
                category = null,
                img = "https://i.ibb.co/x1vQZXr/depositphotos-21635179-stock-photo-couch-isolated-on-white-background.webp",
                price = 17000,
                inStock = true
            };
            Furniture f5 = new Furniture
            {
                id = "5",
                name = "Кровать1",
                category = null,
                img = "https://i.ibb.co/fp7kZkP/6.jpg",
                price = 15000,
                inStock = true
            };
            Furniture f6 = new Furniture
            {
                id = "6",
                name = "Кровать2",
                category = null,
                img = "https://i.ibb.co/H20WbLS/7.jpg",
                price = 17000,
                inStock = true
            };
            Furniture f7 = new Furniture
            {
                id = "7",
                name = "Диван1",
                category = null,
                img = "https://i.ibb.co/XJLm4V3/1.jpg",
                price = 17000,
                inStock = true
            };
            Furniture f8 = new Furniture
            {
                id = "8",
                name = "Диван2",
                category = null,
                img = "https://i.ibb.co/Htd0qzw/2.jpg",
                price = 17000,
                inStock = true
            };
            Furniture f9 = new Furniture
            {
                id = "9",
                name = "Диван3",
                category = null,
                img = "https://i.ibb.co/wSpwPH1/3.jpg",
                price = 17000,
                inStock = true
            };
            db.Furnitures.Add(f1);
            db.Furnitures.Add(f2);
            db.Furnitures.Add(f3);
            db.Furnitures.Add(f4);
            db.Furnitures.Add(f5);
            db.Furnitures.Add(f6);
            db.Furnitures.Add(f7);
            db.Furnitures.Add(f8);
            db.Furnitures.Add(f9);
            db.SaveChanges();
        }
    }
}
