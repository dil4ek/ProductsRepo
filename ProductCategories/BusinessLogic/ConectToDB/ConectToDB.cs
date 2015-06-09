using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//conect to mongo
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


namespace BusinessLogic.ConectToDB
{ 
    public static class ConectToDB
    {
        static public MongoDatabase CreateConection(string url, string nameDB)
        {
            var client = new MongoClient(url);
            var server = client.GetServer();
            var db = server.GetDatabase(nameDB);

            return db;
        
        }
    }
}
