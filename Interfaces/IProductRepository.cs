using bootstrap_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bootstrap_project.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync(); // Получить все продукты
        Task AddProductAsync(Product product);     // Добавить продукт
        Task SaveChangesAsync();                   // Сохранить изменения в базе данных
        Task<IEnumerable<Product>> GetAllAsync();  // Исправлено: тип возвращаемого значения
    }
}





