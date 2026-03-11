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
            b.HasKey(e => e.Id);
            
            b.Property(e => e.Id)
                .HasColumnName("id");

            b.Property(e => e.Name)
                .HasColumnName("name");

            b.OwnsOne(e => e.Address, b2 =>
            {
                b2.Property(e => e.City)
                    .HasColumnName("city");

                b2.OwnsOne(e => e.Country, b3 =>
                {
                    b3.Property(e => e.Name)
                        .HasColumnName("country_name");

                    b3.OwnsOne(e => e.Continent, b4 =>
                    {
                        b4.Property(e => e.Name)
                            .HasColumnName("continent_name");

                        b4.OwnsOne(e => e.Planet, b5 =>
                        {
                            b5.Property(e => e.Name)
                                .HasColumnName("planet_name");

                            b5.OwnsOne(e => e.SolarSystem, b6 =>
                            {
                                b6.Property(e => e.Name)
                                    .HasColumnName("solar_system_name");
                                b6.OwnsOne(e => e.Galaxy, b7 =>
                                {
                                    b7.Property(e => e.Name)
                                        .HasColumnName("galaxy_name");
                                    b7.OwnsOne(e => e.Universe, b8 =>
                                    {
                                        b8.Property(e => e.Name)
                                            .HasColumnName("universe_name");
                                        b8.OwnsOne(e => e.Multiverse, b9 =>
                                        {
                                            b9.Property(e => e.Name)
                                                .HasColumnName("multiverse_name");
                                            b9.OwnsOne(e => e.Hiperverse, b10 =>
                                            {
                                                b10.Property<int>("ManualKeyName");
                                                b10.HasKey("ManualKeyName");
                                                b10.WithOwner()
                                                    .HasForeignKey("ManualKeyName");
                                                b10.Property(e => e.Name)
                                                    .HasColumnName("hiperverse_name");
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });

            b.ToTable("users");
        });
    }
}