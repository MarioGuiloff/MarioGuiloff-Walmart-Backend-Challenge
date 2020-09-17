using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Walmart.Api.Product.Persistence
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _mongoDb;
        private const string Database = "";
        private const string ConnectionString = "";
        private const string CollectionProduct = "";

        public MongoDBContext()
        {
            var client = new MongoClient(ConnectionString);
            _mongoDb = client.GetDatabase(Database);
        }

        public IMongoCollection<Model.Product> Product
        {
            get
            {
                return _mongoDb.GetCollection<Model.Product>(CollectionProduct);
            }
        }
    }
}
