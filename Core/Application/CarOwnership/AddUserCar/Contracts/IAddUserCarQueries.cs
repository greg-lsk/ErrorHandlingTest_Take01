using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.AddUserCar.Contracts;

public interface IAddUserCarQueries
{
    public void AddUserCar(IAddUserCarRequest request);
}