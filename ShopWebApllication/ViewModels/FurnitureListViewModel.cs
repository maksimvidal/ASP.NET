using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApllication.Data;

namespace ShopWebApllication.ViewModels
{
    public class FurnitureListViewModel
    {
        public IEnumerable<Furniture> allFurnitures { get; set; }
        public string pid { get; set; } = "0";

    }
}
