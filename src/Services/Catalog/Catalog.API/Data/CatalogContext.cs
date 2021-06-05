using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var client = new MongoClient(GetConfigValue("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(GetConfigValue("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(GetConfigValue("DatabaseSettings:CollectionName"));
        }


        private string GetConfigValue(string key) => _configuration.GetValue<string>(key);
    }
}
