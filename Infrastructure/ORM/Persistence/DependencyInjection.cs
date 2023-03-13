using Microsoft.Extensions.DependencyInjection;

using Application.DataSource;


namespace ORM.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<BusinessModelDirector>();
                
        services.AddScoped<IDataSource, BusinessModelDirector>
            (provider => provider.GetRequiredService<BusinessModelDirector>());
        
        services.AddScoped<IDataStateTracker, BusinessModelDirector>
            (provider => provider.GetRequiredService<BusinessModelDirector>());

        return services;
    }

}