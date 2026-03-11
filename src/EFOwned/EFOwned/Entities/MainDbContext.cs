using Microsoft.EntityFrameworkCore;

namespace EFOwned.Entities;

public class MainDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public MainDbContext(DbContextOptions<MainDbContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>(b =>
        {
            b.HasKey(u => u.Id);
            
            b.Property(u => u.Id)
                .HasColumnName("id");
            
            b.Property(u => u.Name)
                .HasColumnName("name");

            b.OwnsOne(u => u.HomeAddress, b2 =>
            {
                b2.Property(a => a.City)
                    .HasColumnName("home_city");
                
                b2.Property(a => a.Street)
                    .HasColumnName("home_street");
            });
            
            b.OwnsOne(u => u.WorkAddress, b2 =>
            {
                b2.Property(a => a.City)
                    .HasColumnName("work_city");
                
                b2.Property(a => a.Street)
                    .HasColumnName("work_street");
            });
            
            b.ToTable("users");
        });
    }
}