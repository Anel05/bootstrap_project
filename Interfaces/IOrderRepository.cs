using System.Collections.Generic;
using System.Threading.Tasks;
using bootstrap_project.Models;

namespace bootstrap_project.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order); // Добавлено
        Task<IEnumerable<Order>> GetAllOrdersAsync(); // Добавлено
        Task SaveChangesAsync();
    }
}










