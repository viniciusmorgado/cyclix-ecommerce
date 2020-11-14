using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.Repositories;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetProductByIdAsync(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Product>> GetProductListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}