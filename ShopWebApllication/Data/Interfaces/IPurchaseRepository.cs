using ShopWebApllication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> purchases{ get; }
    }
}
