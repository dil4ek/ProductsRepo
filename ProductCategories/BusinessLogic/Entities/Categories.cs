using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace BusinessLogic
{
    public class Categories
    {
        [BsonId]
        public string ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }


    }
}
