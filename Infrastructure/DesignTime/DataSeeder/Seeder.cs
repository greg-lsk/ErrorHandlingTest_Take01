using Queries.DataAccess;
using DataSeeder.DummyData;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


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
            var accessor = scope.ServiceProvider.GetRequiredService<IDataAccessor>();

            Add(accessor, accessor.Manufacturers, _dummyDataProvider.Manufacturers);
            Add(accessor, accessor.Models, _dummyDataProvider.Models);
        }

    }

    private void Add<TEntity>(IDataAccessor accessor,
                              DbSet<TEntity> set,
                              IEnumerable<TEntity> toAdd)
        where TEntity : class
    {
        set.AddRange(toAdd);
        accessor.SaveChanges();
    }

}