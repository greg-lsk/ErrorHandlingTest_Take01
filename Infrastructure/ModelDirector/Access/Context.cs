using Microsoft.EntityFrameworkCore;

using Domain.Entities;
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


    public Context(DbContextOptions<Context> options) : base(options) {
        Console.WriteLine("Executing Context ctor");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("Configuring Database");

        base.OnConfiguring(optionsBuilder);

        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

        var connectionString = 
            $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";

        /*        optionsBuilder.UseSqlServer(
                    connectionString,
                    b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)*/

        optionsBuilder.UseSqlServer(
            connectionString,
            b => b.MigrationsAssembly("Migrations")
        );
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Console.WriteLine("Configuring Model");

        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new UserConfigurator())
            .ApplyConfiguration(new CarManufacturerConfigurator())
            .ApplyConfiguration(new CarModelConfigurator())
            .ApplyConfiguration(new CarConfigurator())
            .ApplyConfiguration(new CarOwnershipConfigurator());
    }

}