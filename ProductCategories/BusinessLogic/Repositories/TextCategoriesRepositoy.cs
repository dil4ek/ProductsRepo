﻿using System;
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
    public class TextCategoriesRepositoy : ICategoriesRepository
    {
        private MongoCollection<Categories> collection;

        public TextCategoriesRepositoy()
        {
            string url = "mongodb://127.0.0.1";
            string dbName = "ProductCategories";
            var db = ConectToDB.ConectToDB.CreateConection(url, dbName);
            collection = db.GetCollection<Categories>("Categories");
        }

        public Categories GetByName(string catergoryName)
        {
            var query = Query.EQ("CategoryName", catergoryName);

            return collection.Find(query).FirstOrDefault();
        }

        public IEnumerable<Categories> GetAll()
        {
            return collection.FindAll();
        }

        public Categories GetById(string id)
        {
            return collection.FindOneById(id);       
        }

        public Categories Add(Categories item)
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

        public void UpdateCategories(string id, Categories item)
        {
            var query = Query.EQ("_id", id);

            var udpate = Update.Set("CategoryName", item.CategoryName)
                               .Set("Description", item.Description);
            var result =  collection.Update(query, udpate);     
        }

        private int GetCategoryID() {
            IEnumerable<Categories> list = GetAll();
            int id = list.Count() + 1;
            return id;        
        }
     }
}
