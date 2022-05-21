using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Models
{
    public class Purchase
    {
        public string id { get; set; }
        public double price { get; set; }
        public List<Furniture> furnitures { get; set; } = new List<Furniture>();

        public override string ToString() 
        {
            int c=0;
            c = furnitures.Count();
            return "id: " + id + " " + c; 
        }
    }
}
