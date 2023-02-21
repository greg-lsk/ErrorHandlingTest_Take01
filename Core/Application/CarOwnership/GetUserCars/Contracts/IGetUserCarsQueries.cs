using Application.GuidRequest;


namespace Application.CarOwnership.GetUserCars.Contracts;

public interface IGetUserCarsQueries
{
    public IGetUserCarsResponce? GetCars(IGuidRequest request);
}