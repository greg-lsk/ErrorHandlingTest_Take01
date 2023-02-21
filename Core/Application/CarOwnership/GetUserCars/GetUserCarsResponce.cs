using Application.Car.TransferObject;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.GetUserCars;

public class GetUserCarsResponce : IGetUserCarsResponce
{
    public IReadOnlyCollection<ICarDTO>? Cars { get; private set; }


    public GetUserCarsResponce(IReadOnlyCollection<ICarDTO>? cars)
    {
        Cars = cars;
    }

}