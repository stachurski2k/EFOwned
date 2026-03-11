using Microsoft.EntityFrameworkCore;

namespace EFOwned.Entities;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}