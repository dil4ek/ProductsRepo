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

        public TextProductsRepositoy()
        {
            string url = "mongodb://127.0.0.1";
            string dbName = "ProductCategories";
            var db = ConectToDB.ConectToDB.CreateConection(url, dbName);
            collection = db.GetCollection<Products>("Products");
        }

        public IEnumerable<Products> GetProduct(string idCategory, string nameCategory)
        {
            Categories category = new Categories();
            TextCategoriesRepositoy categoryRepo = new TextCategoriesRepositoy();

            if (idCategory != null)
            { 
                var query = Query.EQ("IdCategory", idCategory);
                return collection.Find(query);           
            }

            if (nameCategory != null)
            {
                category = categoryRepo.GetByName(nameCategory);
                var query = Query.EQ("IdCategory", category.ID);
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
            item.ID = GetCategoryID().ToString();
            collection.Insert(item);
            return item;
        }

        public void Delete(string id)
        {
            var query = Query.EQ("_id", id);
            collection.Remove(query);
        }

        public void UpdateProducts(string id, Products item)
        {
            var query = Query.EQ("_id", id);
            if (item == null)
            {
                throw new ArgumentNullException();
            
            }

            var udpate = Update.Set("ID", id)
                               .Set("IdCategory", item.IdCategory)
                               .Set("ProductName", item.ProductName)
                               .Set("ProductDescription", item.ProductDescription)
                               .Set("URLImige", item.URLImige);
            var result = collection.Update(query, udpate);
        }

        private int GetCategoryID()
        {
            IEnumerable<Products> list = GetAll();
            int id = list.Count() + 1;
            return id;
        }
    }
}
