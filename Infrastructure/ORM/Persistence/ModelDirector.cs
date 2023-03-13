using Microsoft.EntityFrameworkCore;

using Domain.Entities;
using Application.DataSource;
using ORM.Persistence.ModelConfiguration;


namespace ORM.Persistence;

public class BusinessModelDirector : DbContext, IDataSource, IDataStateTracker
{
    public DbSet<User> Users { get; set; }
    public DbSet<CarManufacturer> Manufacturers { get; set; }
    public DbSet<CarModel> Models { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarOwnership> CarOwnerships { get; set; }


    public BusinessModelDirector(DbContextOptions<BusinessModelDirector> options) : base(options) { }


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

    public IQueryable<TEntity> Get<TEntity>()
        where TEntity:class
    {
        return Set<TEntity>().AsQueryable();
    }

    public new TEntity Add<TEntity>(TEntity entity)
        where TEntity:class
    {
        var added = Set<TEntity>().Add(entity);
        return added.Entity;
    }


    public void EnableTracking()
        => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    
    public void DisableTracking()
        => ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    
    public int ApplyChanges()
        => SaveChanges();
    
}