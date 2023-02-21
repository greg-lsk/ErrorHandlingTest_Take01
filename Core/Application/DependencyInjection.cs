using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Application.Authentication.Login;
using Application.Authentication.Login.Contracts;
using Application.Authentication.Register;
using Application.Authentication.Register.Contracts;
using Application.CarManufacturer.GetManufacturers;
using Application.CarManufacturer.GetManufacturers.Contracts;
using Application.CarModel.GetModels;
using Application.CarModel.GetModels.Contracts;
using Application.CarOwnership.GetUserCars;
using Application.CarOwnership.GetUserCars.Contracts;
using Application.CarOwnership.AddUserCar.Contracts;
using Application.CarOwnership.AddUserCar;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddTransient<ILoginService, LoginService>()
                .AddTransient(lazy => new Lazy<ILoginService>(
                    () => lazy.GetRequiredService<ILoginService>())
                );
        services.AddTransient<IRegisterService, RegisterService>()
                .AddTransient(lazy => new Lazy<IRegisterService>(
                    () => lazy.GetRequiredService<IRegisterService>())
                );


        services.AddTransient<IGetUserCarsService, GetUserCarsService>()
                .AddTransient(lazy => new Lazy<IGetUserCarsService>(
                    () => lazy.GetRequiredService<IGetUserCarsService>())
                );
        services.AddTransient<IAddUserCarService, AddUserCarService>()
        .AddTransient(lazy => new Lazy<IAddUserCarService>(
            () => lazy.GetRequiredService<IAddUserCarService>())
        );


        services.AddTransient<IGetManufacturersService, GetManufacturersService>()
                .AddTransient(lazy => new Lazy<IGetManufacturersService>(
                    () => lazy.GetRequiredService<IGetManufacturersService>())
                );


        services.AddTransient<IGetModelsService, GetModelsService>()
        .AddTransient(lazy => new Lazy<IGetModelsService>(
            () => lazy.GetRequiredService<IGetModelsService>())
        );

        return services;
    }

}