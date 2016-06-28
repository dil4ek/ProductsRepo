using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.ConectToDB;
using BusinessLogic;
using BusinessLogic.Repositories;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ProductCategories
{
    class Program
    {
        static void Main()
        {

            TextCategoriesRepositoy categoriesRepo = new TextCategoriesRepositoy();
            TextProductsRepositoy productRepo = new TextProductsRepositoy();

            Categories[] items = {new Categories(){CategoryName = "Masa", Description = "Napravena ot durvo"},
                                  new Categories(){CategoryName = "Stol", Description = "Napraven ot plastmasa"},
                                  new Categories(){CategoryName = "Leglo", Description = "Spalnq"}
                                 };

            // insert categories in DB
            //for (int i = 0; i < items.Length; i++)
            //{
            //    categoriesRepo.Add(items[i]);
            //}

           // Categories item = new Categories() { CategoryName = "Buro", Description = "Uchenik" };
           // categoriesRepo.Add(item);

            //test find all
            IEnumerable<Categories> categories = categoriesRepo.GetAll();
          
            var jObject = categories.ToJson();

            Products[] itemsProduct = {
                                 new Products(){ProductName = "Prista", IdCategory = "3", ProductDescription = "hubava prista"},
                                 new Products(){ProductName = "Spalnq", IdCategory = "3", ProductDescription = "golqma spalnq"},
                                 new Products(){ProductName = "tuburetka", IdCategory = "2", ProductDescription = "hubava masa"},
                                 new Products(){ProductName = "kuhnenska Masa", IdCategory = "1", ProductDescription = "hubava masa"},
                                 new Products(){ProductName = "Buro", IdCategory = "4", ProductDescription = "hubava masa"}
                                 };
            // add data in DB
            //for (int i = 0; i < itemsProduct.Length; i++)
            //{
            //    productRepo.Add(itemsProduct[i]);
            //}

            IEnumerable<Products> prods = productRepo.GetAll().AsQueryable();
            string jObjectp = prods.ToJson();
        }
    }
}
