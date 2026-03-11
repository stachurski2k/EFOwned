using Microsoft.EntityFrameworkCore;

namespace EFOwned.Entities;

public class MainDbContext : DbContext
{
    public DbSet<User> Orders { get; set; }
    public MainDbContext(DbContextOptions<MainDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(k => k.Id);
            b.Property(k => k.Id)
                .HasColumnName("id");
            b.Property(k => k.Name)
                .HasColumnName("name");
            
            b.OwnsMany(k => k.Orders, b2 =>
            {
                b2.Property(e => e.OrderDate)
                    .HasColumnName("order_date");
                b2.ToTable("orders");
            });
            
            b.ToTable("users");
        });
    }
}