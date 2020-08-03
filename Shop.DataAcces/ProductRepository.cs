using Entities;
using Shop.Common;
using Shop.Common.Enums;
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

        public List<Product> FindAll(Filters filter)
        {
            IQueryable<Product> products = _dbContext.Items.
                Where(x => x.Category == filter.Category && x.Gender == filter.Gender).
                Where(x => x.IsOverpriced == filter.IsOverpriced).
                Where(x => x.Price >= filter.MinPrice && x.Price <= filter.MaxPrice);

            var selectedColors = filter.SelectedColors;
            
            if (selectedColors.Count() > 0)
                products = products.Where(p => selectedColors.Contains(p.Color));

            var selectedSizes = filter.SelectedSizes;

            Size sizesToSearch = 0;
            selectedSizes.ForEach(x => sizesToSearch = sizesToSearch | x);

            if (selectedSizes.Count() > 0)
                products = products.Where(p => p.Sizes.Any(s => (s.Size & sizesToSearch) != 0));

            switch (filter.SortBy)
            {
                case SortBy.PriceAscending:
                    products = products.OrderBy(p => p.Price);
                    break;
                case SortBy.PriceDescending:
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }

            return products.ToList();
        }

        public async Task<Product> FindOne(int productId)
        {
            return await _dbContext.Items.FindAsync(productId);
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
                await _dbContext.SaveChangesAsync();
            }
            
            // return something to handle errors
        }

        public async Task<Product> Update(Product product)
        {
            if (await _dbContext.Items.FindAsync(product.Id) != null)
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
            }

            return product;
        }
    }
}
