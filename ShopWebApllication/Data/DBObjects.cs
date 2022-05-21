using ShopWebApllication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                return category;
            }
        }
    }
}

