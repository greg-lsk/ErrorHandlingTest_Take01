using Microsoft.EntityFrameworkCore;
using Queries.DataAccess;
using Application.GuidRequest;
using Application.Car.TransferObject;
using Application.CarOwnership.GetUserCars;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Queries.CarOwnsership;

internal class GetUserCarsQueries : DatabaseQuery, IGetUserCarsQueries
{
    public GetUserCarsQueries(IDataAccessor accessor) : base(accessor) { }

    public IGetUserCarsResponce? GetCars(IGuidRequest request)
    {
        var result = _accessor.CarOwnerships
            .AsNoTracking()
            .Where(ownership => ownership.OwnerId == request.Id)
            .Select(ownership => new CarDTO
            (
                ownership.CarId,
                ownership.Car.Model!=null ? ownership.Car.Model.Name : string.Empty
            ))
            .ToList();

        return new GetUserCarsResponce(result);
    }

}