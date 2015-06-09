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

namespace ProductCategories
{
    class Program
    {
        static void Main()
        {

            TextCategoriesRepositoy categoriesRepo = new TextCategoriesRepositoy();
            TextProductsRepositoy productRepo = new TextProductsRepositoy();
           // string url = "mongodb://127.0.0.1";
           // string dbName = "ProductCategories";
           // categoriesRepo.ConectToMongo(url, dbName);

            //Categories item = new Categories();

            Categories[] items = {new Categories(){CategoryName = "Masa", Description = "Napravena ot durvo"},
                                  new Categories(){CategoryName = "Stol", Description = "Napraven ot plastmasa"},
                                  new Categories(){CategoryName = "Leglo", Description = "Spalnq"}
                                 };

            //test insert
            //for (int i = 0; i < items.Length; i++)
            //{
            //    categoriesRepo.Add(items[i]);
            //}

            Categories item = new Categories() { CategoryName = "Buro", Description = "Uchenik" };
            categoriesRepo.Add(item);

            //test find all
            IEnumerable<Categories> categories = categoriesRepo.GetAll();
            //int numb = categories.Count();
            var jObject = categories.ToJson();

            //test find by name
            Categories oneCategory = categoriesRepo.GetByName("Masa");
            Console.WriteLine(oneCategory.ID + " -> " + oneCategory.CategoryName + " -> " + oneCategory.Description);

            //test find by id
          

            //testUpdate 
            Categories updateItem = new Categories() { CategoryName = "Leglo 2", Description = "Prosta" };
            categoriesRepo.UpdateCategories("3", updateItem);

            Categories twoCategory = categoriesRepo.GetById(oneCategory.ID);
            Console.WriteLine(twoCategory.ID + " -> " + twoCategory.CategoryName + " -> " + twoCategory.Description);

           // categoriesRepo.Delete("5572ec1a23bb0517bcd00408");

            //Products[] itemsProduct = {
            //                      new Products(){ProductName = "Prista", IdCategory = "3", ProductDescription = "hubava prista", URLImige = "http://kartinki.eu/details.php?image_id=307999"},
            //                      new Products(){ProductName = "Spalnq", IdCategory = "3", ProductDescription = "golqma spalnq", URLImige = "http://kartinki.eu/details.php?image_id=307999"},
            //                      new Products(){ProductName = "tuburetka", IdCategory = "2", ProductDescription = "hubava masa", URLImige = "http://kartinki.eu/details.php?image_id=307999"},
            //                      new Products(){ProductName = "kuhnenska Masa", IdCategory = "1", ProductDescription = "hubava masa", URLImige = "http://kartinki.eu/details.php?image_id=307999"},
            //                      new Products(){ProductName = "Buro", IdCategory = "4", ProductDescription = "hubava masa", URLImige = "http://kartinki.eu/details.php?image_id=307999"}
            //                     };

            //for (int i = 0; i < itemsProduct.Length; i++)
            //{
            //    productRepo.Add(itemsProduct[i]);
            //}

            IEnumerable<Products> prods = productRepo.GetAll();
            var jObjectp = prods.ToJson();
        }
    }
}
