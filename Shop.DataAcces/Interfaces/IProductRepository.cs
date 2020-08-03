using Entities;
using Shop.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.DataAcces.Interfaces
{
    public interface IProductRepository
    {
        List<Product> FindAll(Filters filters);
        Task<Product> FindOne(int productId);
        Task<Product> Create(Product product);
        Task Remove(int productId);
        Task<Product> Update(Product product);
    }
}
