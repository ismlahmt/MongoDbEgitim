using MongoDB.Bson;
using MongoDbEgitim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbEgitim.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                {"CustomerName", customer.CustomerName },
                {"CustomerSurname", customer.CustomerSurname },
                {"CustomerBalance", customer.CustomerBalance },
                {"ShoppingCount", customer.ShoppingCount },

            };
            customerCollection.InsertOne(document);
        }
    }
}


// bu kod satırları mongo dbde ekleme işlemini gerçekleştiricek olan kısım.