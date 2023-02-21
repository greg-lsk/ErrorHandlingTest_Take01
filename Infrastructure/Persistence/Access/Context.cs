using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using Queries.DataAccess;


namespace Persistence.Access;

public class Context : DbContext, IDataAccessor
{
    public DbSet<User> Users { get; set; }
    public DbSet<CarManufacturer> Manufacturers { get; set; }
    public DbSet<CarModel> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarOwnership> CarOwnerships { get; set; }


    public Context(DbContextOptions<Context> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new UserConfigurator())
            .ApplyConfiguration(new CarManufacturerConfigurator())
            .ApplyConfiguration(new CarModelConfigurator())
            .ApplyConfiguration(new CarConfigurator())
            .ApplyConfiguration(new CarOwnershipConfigurator());
    }

}