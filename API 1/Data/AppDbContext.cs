using API_1.Models;
using Microsoft.EntityFrameworkCore;

namespace API_1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();
    }
}
