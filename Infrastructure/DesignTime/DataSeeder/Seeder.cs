using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Persistence.Access;
using DataSeeder.DummyData;


namespace DataSeeder;

public class Seeder
{
    private readonly IServiceProvider _serviceProvider;
    private readonly DummyDataProvider _dummyDataProvider;

    public Seeder(IServiceProvider provider)
    {
        _serviceProvider = provider;
        _dummyDataProvider = new();
    }


    public void Start()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            Console.WriteLine("Seeding Database");
            var dbContext = scope.ServiceProvider.GetRequiredService<Context>();

            dbContext.Database.Migrate();

            Add(dbContext, dbContext.Manufacturers, _dummyDataProvider.Manufacturers);
            Add(dbContext, dbContext.Models, _dummyDataProvider.Models);
        }

    }

    private void Add<TEntity>(Context dbContext,
                              DbSet<TEntity> set,
                              IEnumerable<TEntity> toAdd)
        where TEntity : class
    {
        set.AddRange(toAdd);
        dbContext.SaveChanges();
    }

}