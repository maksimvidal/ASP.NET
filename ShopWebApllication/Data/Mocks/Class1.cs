using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopWebApllication.Data.Interfaces;

namespace ShopWebApllication.Data.Mocks
{
    public class FurnitureMock : IAllFurnitures
    {

        IEnumerable<Furniture> IAllFurnitures.furnitures
        {
            get
            {
                return new List<Furniture> {
                new Furniture {id = "1", name ="ExtremeRace Black, White (26302174)", inStock=true, price=11234 } ,
                new Furniture {id = "2", name ="Monet 2-местный Багама 35", inStock=true, price=15139 } ,
                new Furniture { id = "3", name = "двуспальная 160х200 мягкая Signal Melissa серое для спальни",inStock=true, price=10284 } ,
                };
            }
        }
    }
}
