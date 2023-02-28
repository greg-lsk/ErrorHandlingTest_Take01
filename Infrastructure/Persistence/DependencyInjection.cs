using Microsoft.Extensions.DependencyInjection;

using Persistence.Access;
using Queries.DataAccess;


namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<Context>();
        services.AddScoped<IDataAccessor, Context>();

        return services;
    }

}