using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//business logic
using BusinessLogic.Interfaces;
using BusinessLogic;
using BusinessLogic.ConectToDB;

//conect to mongo
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace BusinessLogic.Repositories
{
   public class TextProductsRepositoy : IProductsRepository
    {
        private MongoCollection<Products> collection;
        private Categories category = new Categories();
        private TextCategoriesRepositoy categoryRepo = new TextCategoriesRepositoy();

        public TextProductsRepositoy()
        {
            string url = "mongodb://127.0.0.1";
            string dbName = "ProductCategories";
            var db = ConectToDB.ConectToDB.CreateConection(url, dbName);
            collection = db.GetCollection<Products>("Products");
        }

        public IEnumerable<Products> GetProduct(string idCategory, string nameCategory)
        {
            if (idCategory != null)
            { 
                var query = Query.EQ("IdCategory", idCategory);
                return collection.Find(query);           
            }

            if (nameCategory != null)
            {
                category = categoryRepo.GetByName(nameCategory);
                var query = Query.EQ("IdCategory", category.Id);
                return collection.Find(query); ;           
            }

            return null;
        }

        public IEnumerable<Products> GetAll()
        {
            return collection.FindAll();
        }

        public Products GetById(string id)
        {
            return collection.FindOneById(id);
        }

        public Products Add(Products item)
        {
          
            var categoryID = item.IdCategory;
            if (categoryRepo.GetById(categoryID) == null)
            {
                //throw new ArgumentException("No category found");
                return null;

            };

            // item.Id = ObjectId.GenerateNewId().ToString();
            item.Id = GetID();
            collection.Insert(item);
            return item;
        }

        public void Delete(string id)
        {
            var query = Query.EQ("_id", id);
            collection.Remove(query);
        }

        public void UpdateItem(Products item)
        {
            var query = Query.EQ("_id", item.Id);
            if (item == null)
            {
                throw new ArgumentNullException();
            
            }

            var categoryID = item.IdCategory;
            if (categoryID == null)
            {
                throw new ArgumentNullException();

            }

            var udpate = Update.Set("IdCategory", item.IdCategory)
                               .Set("ProductName", item.ProductName)
                               .Set("ProductDescription", item.ProductDescription);
            var result = collection.Update(query, udpate);
        }

        private string GetID()
        {
            IEnumerable<Products> list = GetAll();
            Products lastProduct = list.LastOrDefault();
            int idLastProduct = lastProduct != null ? int.Parse(lastProduct.Id) : 0;
            int idNum = idLastProduct + 1;
            return idNum.ToString();
        }
    }
}
