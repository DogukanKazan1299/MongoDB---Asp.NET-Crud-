using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDBCrud.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
namespace MongoDBCrud.Models
{
    public class AccountModel
    {

        private MongoClient mongoClient;
        private IMongoCollection<Account> accountCollection;

        public AccountModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);

            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);

            accountCollection = db.GetCollection<Account>("account");

        }


        public List<Account> findAll()
        {
            return accountCollection.AsQueryable<Account>().ToList();
        }

        public Account find(string id)
        {
            var accountId = new ObjectId(id);
            return accountCollection.AsQueryable<Account>().SingleOrDefault(a => a.Id == accountId);
        }

        public void create(Account account)
        {
            accountCollection.InsertOne(account);
        }

        public void update(Account account)
        {
            accountCollection.UpdateOne(Builders<Account>.Filter.Eq("_id", account.Id),

                Builders<Account>.Update
                .Set("name", account.Name)
                .Set("surname", account.Surname)
                .Set("price", account.Price)
                .Set("status", account.Status)

                );
                
        }

        public void delete(string id)
        {
            accountCollection.DeleteOne(Builders<Account>.Filter.Eq("_id", ObjectId.Parse(id)));
        }

    }
}