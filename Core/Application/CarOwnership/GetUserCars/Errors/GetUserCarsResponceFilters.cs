using ErrorHandler.Traversable;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.GetUserCars.Errors;

public class GetUserCarsResponceFilters : FilterChain<IGetUserCarsResponce>
{
    protected override Enum SuccessInfo { get; init; }


    public GetUserCarsResponceFilters()
    {
        SuccessInfo = GetUserCarsInfo.Success;

        AddFilter(
            responce => responce.Cars == null || responce.Cars.Count == 0,
            GetUserCarsInfo.NoOwnedCars);
    }

}