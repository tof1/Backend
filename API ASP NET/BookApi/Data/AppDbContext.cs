using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(e =>
        {
            e.Property(b => b.Title).IsRequired().HasMaxLength(200);
            e.Property(b => b.Author).IsRequired().HasMaxLength(100);
            e.Property(b => b.Price).HasPrecision(18, 2);
        });
    }
}