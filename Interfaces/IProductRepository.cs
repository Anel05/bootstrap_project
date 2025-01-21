using bootstrap_project.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bootstrap_project.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync(); 
        Task AddProductAsync(Product product);     
        Task SaveChangesAsync();                   
        Task<IEnumerable<Product>> GetAllAsync();  
    }
}





