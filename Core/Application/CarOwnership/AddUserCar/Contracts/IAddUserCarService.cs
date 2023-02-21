using ErrorHandler;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.AddUserCar.Contracts;

public interface IAddUserCarService
{
    public void Run(IAddUserCarRequest request);
}