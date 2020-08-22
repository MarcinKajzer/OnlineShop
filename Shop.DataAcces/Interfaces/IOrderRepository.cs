using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAcces.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> Create(Order order);
        Task<Order> Send(int id);
        List<Order> FindAllNotSent();
        List<Order> FindAllSent();
        Task<Order> FindOne(int orderId);
        Task<Order> Update(Order order);
    }
}
