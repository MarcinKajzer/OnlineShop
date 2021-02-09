using Entities;
using Shop.DataAcces.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DataAcces
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            await _context.Orders.AddAsync(order);
            var created = await _context.SaveChangesAsync();

            if(created > 0)
                return order;

            return null;
        }

        public async Task<Order> Send(int id)
        {
            Order order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                order.IsSent = true;
                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }

        public List<Order> FindAllNotSent()
        {
            return _context.Orders.Where(o => !o.IsSent).OrderByDescending(o => o.CreationDate).ToList();
        }

        public List<Order> FindAllSent()
        {
            return _context.Orders.Where(o => o.IsSent).OrderByDescending(o => o.CreationDate).ToList();
        }

        public List<Order> FindByUserId(string userId)
        {
            return _context.Orders.Where(o => o.UserId == userId).OrderByDescending(o => o.CreationDate).ToList();
        }

        public async Task<Order> FindOne(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<Order> Update(Order order)
        {
            if (await _context.Orders.FindAsync(order.Id) != null)
            {
                _context.Update(order);
                await _context.SaveChangesAsync();
            }

            return order;
        }
    }
}
