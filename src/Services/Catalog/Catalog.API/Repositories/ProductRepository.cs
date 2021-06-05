using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task CreateProductAsync(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> productFilter = Builders<Product>.Filter.Eq(prop => prop.Id, id);
            DeleteResult deleteResult = await _catalogContext.Products.DeleteOneAsync(productFilter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName)
        {
            return await _catalogContext.Products.Find(p => p.Category == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            return await _catalogContext.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _catalogContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
