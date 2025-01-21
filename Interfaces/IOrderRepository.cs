using System.Collections.Generic;
using System.Threading.Tasks;
using bootstrap_project.Models;

namespace bootstrap_project.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order order); 
        Task<IEnumerable<Order>> GetAllOrdersAsync(); 
        Task SaveChangesAsync();
    }
}










