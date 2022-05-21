using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopWebApllication.Data;
using ShopWebApllication.Data.Interfaces;
using ShopWebApllication.Data.Mocks;
using ShopWebApllication.Data.Repository;
using ShopWebApllication.ViewModels;

namespace ShopWebApllication.Controllers
{
    public class FurnitureController : Controller
    {
        public IAllFurnitures allFurnitures;
        public string pid { get; set; } = "0";

        public FurnitureController(IAllFurnitures all) 
        {
            allFurnitures = all;
        }
        public ActionResult All()
        {
            FurnitureListViewModel viewModel = new FurnitureListViewModel();
            viewModel.allFurnitures = allFurnitures.furnitures;
            return View(viewModel);
        }  
    }
}
