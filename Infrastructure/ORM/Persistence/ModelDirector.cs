using Microsoft.EntityFrameworkCore;

using Domain.Entities;
using ORM.Persistence.ModelConfiguration;
using Queries.DataAccess;


namespace ORM.Persistence;

public class ModelDirector : DbContext, IDataAccessor
{
    public DbSet<User> Users { get; set; }
    public DbSet<CarManufacturer> Manufacturers { get; set; }
    public DbSet<CarModel> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarOwnership> CarOwnerships { get; set; }


    public ModelDirector(DbContextOptions<ModelDirector> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");

        var connectionString =
            $"Data Source={dbHost};" +
            $"Initial Catalog={dbName};" +
            $"User ID=sa;Password={dbPassword};" +
            $"TrustServerCertificate=True";

        optionsBuilder.UseSqlServer(
            connectionString,
            b => b.MigrationsAssembly("Migrations")
        );
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        new ModelConfigurator(builder);
    }

}