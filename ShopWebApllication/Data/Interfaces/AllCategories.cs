﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApllication.Data.Interfaces
{
    interface IAllCategories
    {
        IEnumerable<Category> categories { get; }
    }
}
