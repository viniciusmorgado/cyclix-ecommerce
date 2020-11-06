using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IReadOnlyList<Product>> GetProductListAsync();
    }
}