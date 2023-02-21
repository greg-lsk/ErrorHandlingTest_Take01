using ErrorHandler;
using Application.GuidRequest;


namespace Application.CarOwnership.GetUserCars.Contracts;

public interface IGetUserCarsService
{
    public IResult<IGetUserCarsResponce> Run(IGuidRequest request);
}