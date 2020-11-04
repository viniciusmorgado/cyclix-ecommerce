using Microsoft.EntityFrameworkCore;

namespace API.Models.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base (options) {}

        public DbSet<Product> Products { get; set; }
    }
}