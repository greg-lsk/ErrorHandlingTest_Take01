using ErrorHandler.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ErrorHandler.Utills;

public static class DependencyInjection
{
    public static IServiceCollection AddErrorHandler(
        this IServiceCollection services)
    {
        services.AddSingleton<ChainProvider>();
        services.AddScoped<IFilteringService, FilteringService>();

        return services;
    }
}