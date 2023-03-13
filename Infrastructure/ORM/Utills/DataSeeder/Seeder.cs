using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using DataSeeder.DummyData;
using ORM.Persistence;

namespace ORM.Utills.DataSeeder;

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
            var dbContext = scope.ServiceProvider.GetRequiredService<BusinessModelDirector>();

            dbContext.Database.Migrate();

            Add(dbContext, dbContext.Manufacturers, _dummyDataProvider.Manufacturers);
            Add(dbContext, dbContext.Models, _dummyDataProvider.Models);
        }

    }

    private void Add<TEntity>(BusinessModelDirector dbContext,
                              DbSet<TEntity> set,
                              IEnumerable<TEntity> toAdd)
        where TEntity : class
    {
        set.AddRange(toAdd);
        dbContext.ApplyChanges();
    }

}