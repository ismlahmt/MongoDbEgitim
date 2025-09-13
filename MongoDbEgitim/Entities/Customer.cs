using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbEgitim.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public decimal CustomerBalance { get; set; }
        public int ShoppingCount { get; set; }



    }
}



//mongodb de idler string olarak tutulur.
//ms sql de tablolar mongodbde koleksiyon olarak adlandırılır.
//ms sqlde row girişi mongoda döküman olarak adlandırılıyor.
// bson (Binary Json) mongo dbde veri kullanımı ve aktarımı için kullanılan özel bir ikili veri formatıdır.
// ObjectId ise ms sql deki birincil anahtar ve identity spesificationa denk geliyor.
