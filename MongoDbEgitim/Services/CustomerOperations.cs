﻿using Amazon.S3.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbEgitim.Entities;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        public List<Customer> GetAllCustomer()
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var customers = customerCollection.Find(new BsonDocument()).ToList();
            List<Customer> customerList= new List<Customer>();
            foreach (var c in customers)
            {
                customerList.Add(new Customer
                {
                    CustomerId = c["_id"].ToString(),
                    CustomerBalance = decimal.Parse(c["CustomerBalance"].ToString()),
                    CustomerName = c["CustomerName"].ToString(),
                    ShoppingCount = int.Parse(c["ShoppingCount"].ToString()),
                    CustomerSurname = c["CustomerSurname"].ToString()
                });

            }
            return customerList;
        }
        public void DeleteCustomer(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            customerCollection.DeleteOne(filter);
        }
        public void UpdateCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerId));
            var updatedValue = Builders<BsonDocument>.Update
                .Set("CustomerName", customer.CustomerName)
                .Set("CustomerSurname", customer.CustomerSurname)
                .Set("CustomerBalance", customer.CustomerBalance)
                .Set("ShoppingCount", customer.ShoppingCount);
            customerCollection.UpdateOne(filter,updatedValue);
        }
        public Customer GetCustomerById(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(id));
            var result = customerCollection.Find(filter).FirstOrDefault();
            return new Customer()
            {
                CustomerBalance = decimal.Parse(result["CustomerBalance"].ToString()),
                CustomerName = result["CustomerName"].ToString(),
                CustomerSurname = result["CustomerSurname"].ToString(),
                ShoppingCount = int.Parse(result["ShoppingCount"].ToString()),
                CustomerId = id
            };
        }

    }



}


// bu kod satırları mongo dbde ekleme işlemini gerçekleştiricek olan kısım.