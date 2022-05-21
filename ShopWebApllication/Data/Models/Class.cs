using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Models
{
    public class Bucket
    {
        List<Furniture> furnitures { get; set; } = new List<Furniture>();
        Purchase purchase { get; set; }
        int quantity { get; set; }

        public void addFurniture(Furniture furniture) 
        {
            furnitures.Add(furniture);
            quantity = furnitures.Count();
        }
    }
}
