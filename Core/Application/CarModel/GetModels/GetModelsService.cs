using ErrorHandler;
using BusinessModel = Domain.Entities;
using Application.DataSource;
using Application.GuidRequest;
using Application.CarModel.TransferObject;
using Application.CarModel.GetModels.Errors;
using Application.CarModel.GetModels.Contracts;


namespace Application.CarModel.GetModels;

internal class GetModelsService : IGetModelsService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;
    private readonly IFilteringService _filteringService;

    public GetModelsService(IDataSource dataSource,
                            IDataStateTracker dataStateTracker,
                            IFilteringService service)
    {
        _filteringService = service;
        _dataStateTracker = dataStateTracker;
        _dataSource = dataSource;
    }


    public IResult<IGetModelsResponce> Run(IGuidRequest request)
    {
        _dataStateTracker.DisableTracking();
        IGetModelsResponce responce = new GetModelsResponce
        (
            _dataSource.Get<BusinessModel::CarModel>()
                       .Where(model => model.Manufacturer.Id == request.Id)
                       .Select(model => new CarModelDTO(model.Id,
                                                        model.Name,
                                                        $"{model.ProductionPeriod}")
                       )
                       .ToList()
        );

        _filteringService[typeof(GetModelsFilters)]
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }
    
}