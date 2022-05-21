using ShopWebApllication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data
{
    public class Furniture
    {
        public string id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public bool inStock { get; set; }
        public Category category { get; set; }
        public List<Purchase> purchases { get; set; } = new List<Purchase>();
        public string img { get; set; }
    }
}
