using Application.Car.TransferObject;


namespace Application.CarOwnership.GetUserCars.Contracts;

public interface IGetUserCarsResponce
{
    public IReadOnlyCollection<ICarDTO>? Cars { get; }
}