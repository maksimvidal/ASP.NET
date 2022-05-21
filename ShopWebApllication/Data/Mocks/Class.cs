using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApllication.Data.Interfaces;

namespace ShopWebApllication.Data.Mocks
{
    public class MockCategory : IAllCategories
    {
        public IEnumerable<Category> categories
        {
            get
            {
                return new List<Category> {
                new Category {id = "1", name ="Sofas" } ,
                new Category {id = "2", name ="Chairs" } ,
                new Category {id = "3", name ="Beds" } ,
                };
            }
        }
    }
}
