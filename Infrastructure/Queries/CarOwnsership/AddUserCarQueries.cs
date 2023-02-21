using Domain.Entities;
using Queries.DataAccess;
using Application.CarOwnership.AddUserCar.Contracts;


namespace Queries.CarOwnsership;

internal class AddUserCarQueries : DatabaseQuery, IAddUserCarQueries
{

    public AddUserCarQueries(IDataAccessor accessor) : base(accessor) { }


    public void AddUserCar(IAddUserCarRequest request)
    {
        var user = _accessor.Users
            .FirstOrDefault(user => user.Id == request.UserId);

        var model = _accessor.Models
            .FirstOrDefault(model => model.Id == request.ModelId);

        var car = new Car(model);
        _accessor.Cars.Add(car);
        
        var ownsership = new CarOwnership(user, car);
        _accessor.CarOwnerships.Add(ownsership);

        _accessor.SaveChanges();
    }

}