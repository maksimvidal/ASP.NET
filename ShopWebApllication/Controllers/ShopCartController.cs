using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebApllication.Data;
using ShopWebApllication.Data.Interfaces;
using ShopWebApllication.Data.Models;
using ShopWebApllication.ViewModels;

namespace ShopWebApllication.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly AppDBContent db;
        public ShopCartController(IPurchaseRepository _purchaseRepository, AppDBContent _db)
        {
            purchaseRepository = _purchaseRepository;
            db = _db;
        }
        public ViewResult Index(string pid)
        {
            try
            {
                var obj = new ShopCartViewModel
                {
                    purchase = db.Purchases.Include(p => p.furnitures).Where(p => p.id == pid).Single()
                };

                return View(obj);
            }
            catch (Exception ex) 
            {
                createIfNotExists(pid);
                return Index(pid);
            }
        }

        public ViewResult End(string pid)
        {
            Purchase purchase = db.Purchases.Find(pid); 
            db.Entry(purchase).State = EntityState.Deleted;
            db.SaveChanges();
            var obj = new FurnitureListViewModel
            {
                allFurnitures = db.Furnitures
            };
            return View(obj);
        }

        public RedirectResult Buy(string id, string pid)
        {
            var obj = new FurnitureListViewModel
            {
                allFurnitures = db.Furnitures
            };
            Purchase purchase = createIfNotExists(pid);
            if (!hasFurniture(id,pid))
            {
                Console.WriteLine("Daaa");
                purchase.furnitures.Add(db.Furnitures.Find(id));
            }
            
            db.SaveChanges();
            db.Purchases.Include(p => p.furnitures).ToList().ForEach(x => Console.WriteLine(x));
            return Redirect("/Furniture/All");
        }

        public void Remove(string fid, string pid)
        {
            var obj = new ShopCartViewModel
            {
                purchase = db.Purchases.Include(p => p.furnitures).Where(p => p.id == pid).Single()
            };
            if (hasFurniture(fid, pid))
            {
                obj.purchase.furnitures.Remove(db.Furnitures.Find(fid));
            }

            db.SaveChanges();
            db.Purchases.Include(p => p.furnitures).ToList().ForEach(x => Console.WriteLine(x));
            Response.Redirect("/ShopCart/Index?pid=" + pid);
        }
        protected Purchase createIfNotExists(string pid) 
        {
            Purchase purchase;
            if (db.Purchases.Find(pid) == null)
            {
                purchase = new Purchase { id = pid, price = 0 };
                db.Add(purchase);
                db.SaveChanges();
            }
            else
            {
                purchase = db.Purchases.Find(pid);
 //               purchase.furnitures.Add(db.Furnitures.Find(id));
            }

            return purchase;
        }

        protected bool hasFurniture(string fid, string pid)
        { 
            Furniture furniture = db.Furnitures.Find(fid);
            return db.Purchases
                .Include(p => p.furnitures)
                .Where(p => p.id==pid)
                .Single()
                .furnitures
                .Contains(furniture);
        }
    }
}
