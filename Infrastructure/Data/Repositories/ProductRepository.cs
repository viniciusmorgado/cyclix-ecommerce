using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public async Task<IReadOnlyList<Product>> GetProductListAsync()
        {
            return await context.Products.ToListAsync();
        }
    }
}