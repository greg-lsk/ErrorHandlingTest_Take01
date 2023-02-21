using Microsoft.Extensions.DependencyInjection;


namespace Api;

public static class DependencyInjection
{

    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services
            .AddMvcCore()
            .AddControllersAsServices();

        return services;
    }

}
