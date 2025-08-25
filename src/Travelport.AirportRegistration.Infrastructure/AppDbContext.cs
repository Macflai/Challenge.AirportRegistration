using Travelport.AirportRegistration.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Travelport.AirportRegistration.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Person> People => Set<Person>();
    public DbSet<Airport> Airports => Set<Airport>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Surname).IsRequired();
            entity.Property(p => p.PassportNumber).IsRequired();
            entity.HasOne(p => p.Airport)
                  .WithMany(a => a.People)
                  .HasForeignKey(p => p.AirportId);
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Code).IsRequired().HasMaxLength(3);
            entity.Property(a => a.Name).IsRequired();
        });

        // Seed airports
        modelBuilder.Entity<Airport>().HasData(
            new Airport { Id = 1, Code = "MAD", Name = "Adolfo Suárez Madrid–Barajas Airport" },
            new Airport { Id = 2, Code = "BCN", Name = "Barcelona–El Prat Airport" },
            new Airport { Id = 3, Code = "AGP", Name = "Málaga Airport" },
            new Airport { Id = 4, Code = "PMI", Name = "Palma de Mallorca Airport" },
            new Airport { Id = 5, Code = "ALC", Name = "Alicante–Elche Airport" },
            new Airport { Id = 6, Code = "LPA", Name = "Gran Canaria Airport" },
            new Airport { Id = 7, Code = "TFS", Name = "Tenerife South Airport" },
            new Airport { Id = 8, Code = "VLC", Name = "Valencia Airport" },
            new Airport { Id = 9, Code = "SVQ", Name = "Seville Airport" },
            new Airport { Id = 10, Code = "BIO", Name = "Bilbao Airport" },
            new Airport { Id = 11, Code = "IBZ", Name = "Ibiza Airport" },
            new Airport { Id = 12, Code = "MAH", Name = "Menorca Airport" },
            new Airport { Id = 13, Code = "SCQ", Name = "Santiago de Compostela Airport" },
            new Airport { Id = 14, Code = "OVD", Name = "Asturias Airport" },
            new Airport { Id = 15, Code = "GRO", Name = "Girona–Costa Brava Airport" }
        );
    }
}
