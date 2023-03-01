using Microsoft.Extensions.DependencyInjection;
using Queries.DataAccess;


namespace ORM.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ModelDirector>();
        services.AddScoped<IDataAccessor, ModelDirector>();

        return services;
    }

}