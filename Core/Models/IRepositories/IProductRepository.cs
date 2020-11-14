using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Models.IRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductListAsync();
    }
}