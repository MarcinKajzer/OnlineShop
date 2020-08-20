using Entities;
using Shop.DataAcces.Interfaces;
using System;
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
    }
}
