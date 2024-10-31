using bootstrap_project.Data;
using bootstrap_project.Interfaces;
using bootstrap_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bootstrap_project.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // Получение всех продуктов из базы данных
        public async Task<List<Product>> GetAllProductsAsync()
        {
            // Обработка исключений
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                // Можно логировать исключение или обработать его по-другому
                throw new Exception("Ошибка при получении продуктов из базы данных.", ex);
            }
        }

        // Добавление нового продукта
        public async Task AddProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Продукт не может быть null.");
            }

            await _context.Products.AddAsync(product);
        }

        // Сохранение изменений в базе данных
        public async Task SaveChangesAsync()
        {
            // Обработка исключений
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Можно логировать исключение или обработать его по-другому
                throw new Exception("Ошибка при сохранении изменений в базе данных.", ex);
            }
        }

        // Переиспользование метода для получения всех продуктов
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await GetAllProductsAsync(); // Переиспользуем метод
        }
    }
}






