using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.DataAcces.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> FindByCategory(int gender, int category);
        Task<Product> FindOne(int productId);
        Task<Product> Create(Product product);
        Task Remove(int productId);
        Task<Product> Update(Product product);

    }
}
