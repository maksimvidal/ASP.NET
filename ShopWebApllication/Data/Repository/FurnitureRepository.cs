using ShopWebApllication.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Repository
{
    public class FurnitureRepository : IAllFurnitures
    {
        private readonly AppDBContent appDBContent;
        public FurnitureRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Furniture> furnitures => appDBContent.Furnitures.ToList();
    }
}
