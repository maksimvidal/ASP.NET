using ShopWebApllication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.ViewModels
{
    public class ShopCartViewModel : FurnitureListViewModel
    {
        public Purchase purchase { get; set; }
        
    }
}
