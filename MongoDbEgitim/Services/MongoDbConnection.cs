using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbEgitim.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database;
        public MongoDbConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("DbEgitimCustomer");
        }

        public IMongoCollection<BsonDocument> GetCustomersCollection()
        {
            return _database.GetCollection<BsonDocument>("Customers");
        }


    }
}


//return _database.GetCollection<BsonDocument>("Customers"); (Line 22) bu satırda yazılan kod DbEgitimCustomer databasemizin içinde bize customers collectionu (ms sql deki tablo) oluşturuyor.
// Line 17 client.GetDatabase("DbEgitimCustomer") satırı bize DbEgitimCustomer adlı bir veritabanı oluşturmamızı sağlıyor.