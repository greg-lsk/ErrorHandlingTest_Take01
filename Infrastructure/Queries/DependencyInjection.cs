using Microsoft.Extensions.DependencyInjection;

using Queries.Authentication;
using Application.Authentication.Login.Contracts;
using Application.Authentication.Register.Contracts;
using Queries.CarManufacturer;
using Application.CarManufacturer.GetManufacturers.Contracts;
using Queries.CarModel;
using Application.CarModel.GetModels.Contracts;
using Queries.CarOwnsership;
using Application.CarOwnership.GetUserCars.Contracts;
using Application.CarOwnership.AddUserCar.Contracts;

namespace Queries;

public static class DependencyInjection
{

    public static IServiceCollection AddQueries(
        this IServiceCollection services)
    {
        services.AddTransient<ILoginQueries, LoginQueries>();
        services.AddTransient<IRegisterQueries, RegisterQueries>();


        services.AddTransient<IGetUserCarsQueries, GetUserCarsQueries>();


        services.AddTransient<IGetManufacturersQueries, GetManufacturersQueries>();


        services.AddTransient<IGetModelsQueries, GetModelsQueries>();
        services.AddTransient<IAddUserCarQueries, AddUserCarQueries>();

        return services;
    }

}