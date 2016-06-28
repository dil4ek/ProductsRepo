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
    public class Products
    {
        [BsonId]
        public string Id{ get; set; }
        public string IdCategory { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
    }
}
