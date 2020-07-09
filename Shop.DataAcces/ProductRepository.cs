using Entities;
using Shop.DataAcces.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DataAcces
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> FindByCategory(int gender, int category)
        {
            //remove asEnumerable
            return _dbContext.Items.AsEnumerable().Where(x => (int)x.Category == category && (int)x.Gender == gender);
        }

        public async Task<Product> FindOne(int productId)
        {
            Product prod = await _dbContext.Items.FindAsync(productId);
            if(prod != null)
            {
                return prod;
            }

            return null;
        }

        public async Task<Product> Create(Product product)
        {
            await _dbContext.Items.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task Remove(int productId)
        {
            Product prod = await _dbContext.Items.FindAsync(productId);
            if(prod != null)
            {
                prod.IsArchived = true;
            }
            await _dbContext.SaveChangesAsync();
            // return something to handle errors
        }

        public async Task<Product> Update(Product product)
        {
            if (await _dbContext.Items.FindAsync(product.Id) != null)
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }

            return null;
        }
    }
}
