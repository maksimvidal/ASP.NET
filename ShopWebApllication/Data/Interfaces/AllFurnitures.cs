using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Interfaces
{
    public interface IAllFurnitures
    {
        IEnumerable<Furniture> furnitures { get; }
    }
}
