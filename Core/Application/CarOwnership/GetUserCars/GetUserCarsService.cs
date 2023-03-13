using ErrorHandler;
using BusinessModel = Domain.Entities;
using Application.DataSource;
using Application.GuidRequest;
using Application.Car.TransferObject;
using Application.CarOwnership.GetUserCars.Errors;
using Application.CarOwnership.GetUserCars.Contracts;


namespace Application.CarOwnership.GetUserCars;

internal class GetUserCarsService : IGetUserCarsService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;
    private readonly IFilteringService _filteringService;


    public GetUserCarsService(IDataSource dataSource,
                              IDataStateTracker dataStateTracker,
                              IFilteringService service)
    {
        _filteringService = service;
        _dataStateTracker = dataStateTracker;
        _dataSource = dataSource;
    }


    public IResult<IGetUserCarsResponce> Run(IGuidRequest request)
    {
        _dataStateTracker.DisableTracking();
        IGetUserCarsResponce responce = new GetUserCarsResponce
        (
            _dataSource.Get<BusinessModel::CarOwnership>()
                       .Where(ownership => ownership.OwnerId == request.Id)
                       .Select(ownership => new CarDTO(
                           ownership.CarId,
                           ownership.Car.Model != null ? ownership.Car.Model.Name : string.Empty)
                       )
                       .ToList()
        );

        _filteringService[typeof(GetUserCarsResponceFilters)]
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }

}