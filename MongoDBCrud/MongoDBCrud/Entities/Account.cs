using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCrud.Entities
{
    public class Account
    {

        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }
        [BsonElement("name")]
        public string Name
        {
            get;
            set;
        }
        [BsonElement("surname")]
        public string Surname
        {
            get;
            set;
        }
        [BsonElement("price")]
        public int Price
        {
            get;
            set;
        }
        [BsonElement("status")]
        public bool Status
        {
            get;
            set;
        }


    }
}