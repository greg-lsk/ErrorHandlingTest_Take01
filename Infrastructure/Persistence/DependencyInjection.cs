using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Persistence.Access;
using Queries.DataAccess;


namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<Context>(options =>
            options.UseSqlServer
            (
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(Context).Assembly.FullName)
            )
        );

        services.AddScoped<IDataAccessor, Context>();

        return services;
    }

}