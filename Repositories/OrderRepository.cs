using System.Collections.Generic;
using System.Threading.Tasks;
using bootstrap_project.Data;
using bootstrap_project.Interfaces;
using bootstrap_project.Models;
using Microsoft.EntityFrameworkCore;

namespace bootstrap_project.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {

        public async Task<Order> AddOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);     
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await context.Orders.Include(o => o.Product).ToListAsync(); // Включаем связанные данные о продукте
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}








