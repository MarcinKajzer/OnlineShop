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

        public List<Product> FindAll(Filters filters)
        {
            List<Product> products = DoFiltering(filters);

            products = DoSorting(products, filters.SortBy);

            return products;
        }

        public async Task<Product> FindOne(int productId)
        {
            return await _dbContext.Products.FindAsync(productId);
        }

        public async Task<Product> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            if (await _dbContext.Products.FindAsync(product.Id) != null)
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
            }

            return product;
        }


        private List<Product> DoFiltering(Filters filters)
        {
            IQueryable<Product> products = _dbContext.Products.
                Where(x => x.Price >= filters.MinPrice && x.Price <= filters.MaxPrice).
                Where(x => !x.IsArchived);

            if (filters.Category != null && filters.Gender != null)
                products = products.Where(x => x.Category == filters.Category && x.Gender == filters.Gender);

            if (!string.IsNullOrEmpty(filters.SearchBoxValue))
                products = products.Where(p => p.Name.Contains(filters.SearchBoxValue));

            if (filters.IsOverpriced)
                products = products.Where(p => p.IsOverpriced);

            if (filters.SelectedColors.Count() > 0)
                products = products.Where(p => filters.SelectedColors.Contains(p.Color));

            Size sizesToSearch = 0;
            filters.SelectedSizes.ForEach(x => sizesToSearch |= x);

            if (filters.SelectedSizes.Count() > 0)
                products = products.Where(p => p.Sizes.Where(s => s.Quantity > 0).Any(s => (s.Size & sizesToSearch) != 0));

            return products.ToList();
        }

        private List<Product> DoSorting(List<Product> products, SortBy sortBy)
        {
            switch (sortBy)
            {
                case SortBy.PriceAscending:
                    products = products.OrderBy(p => p.Price).ToList();
                    break;
                case SortBy.PriceDescending:
                    products = products.OrderByDescending(p => p.Price).ToList();
                    break;
            }
            return products;
        }
    }
}
