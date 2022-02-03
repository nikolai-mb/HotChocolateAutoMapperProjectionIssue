using HotChocolateAutoMapperProjectionIssue.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateAutoMapperProjectionIssue.Repository;

public class AutomobileRepository : DbContext
{
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public AutomobileRepository(DbContextOptions<AutomobileRepository> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Driver>().HasData(new[]
        {
            new Driver { Id = 1, Guid = Guid.NewGuid(), Name = "Bob Marley", LicenseNumber = "xyz" },
            new Driver { Id = 2, Guid = Guid.NewGuid(), Name = "Michael Jackson", LicenseNumber = "vyz" }
        });

        builder.Entity<Vehicle>().HasData(new[]
        {
            new Vehicle { Id = 1, Guid = Guid.NewGuid(), ManufactureDate = new DateTime(2011, 04, 02), DriverId = 1 },
            new Vehicle { Id = 2, Guid = Guid.NewGuid(), ManufactureDate = new DateTime(2014, 11, 23), DriverId = 2 },
            new Vehicle { Id = 3, Guid = Guid.NewGuid(), ManufactureDate = new DateTime(2019, 07, 11), DriverId = 2 },
        });
    }
}