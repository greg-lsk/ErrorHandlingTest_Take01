using ErrorHandler;
using Application.GuidRequest;
using Application.CarOwnership.GetUserCars.Errors;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.GetUserCars;

internal class GetUserCarsService : IGetUserCarsService
{
    private readonly IGetUserCarsQueries _queries;
    private readonly IFilteringService _filterService;


    public GetUserCarsService(IGetUserCarsQueries queries,
                         IFilteringService filterService)
    {
        _queries = queries;
        _filterService = filterService;
    }


    public IResult<IGetUserCarsResponce> Run(IGuidRequest request)
    {
        var responce = _queries.GetCars(request);

        _filterService[typeof(GetUserCarsResponceFilters)]
            .Filter(responce)
            .Run();

        return _filterService.YieldResult(responce);
    }

}