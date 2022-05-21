using ShopWebApllication.Data.Interfaces;
using ShopWebApllication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly AppDBContent appDBContent;
        public PurchaseRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Purchase> purchases => appDBContent.Purchases;
    }
}
