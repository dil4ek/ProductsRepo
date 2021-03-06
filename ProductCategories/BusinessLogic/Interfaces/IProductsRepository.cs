﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    interface IProductsRepository : IGenericRepository<Products> 
    {
        IEnumerable<Products> GetProduct(string idCategory, string nameCategory);
    }
}
