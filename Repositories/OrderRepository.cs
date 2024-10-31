using System.Collections.Generic;
using System.Threading.Tasks;
using bootstrap_project.Data;
using bootstrap_project.Interfaces;
using bootstrap_project.Models;
using Microsoft.EntityFrameworkCore;

namespace bootstrap_project.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            // Убрали вызов SaveChangesAsync здесь
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.Product).ToListAsync(); // Включаем связанные данные о продукте
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}








