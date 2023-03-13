using ErrorHandler;
using BusinessModel = Domain.Entities;
using Application.DataSource;
using Application.CarManufacturer.TransferObject;
using Application.CarManufacturer.GetManufacturers.Errors;
using Application.CarManufacturer.GetManufacturers.Contracts;


namespace Application.CarManufacturer.GetManufacturers;

internal class GetManufacturersService : IGetManufacturersService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;
    private readonly IFilteringService _filteringService;


    public GetManufacturersService(IDataSource dataSource,
                                   IDataStateTracker dataStateTracker,
                                   IFilteringService service)
    {
        _filteringService = service;
        _dataStateTracker = dataStateTracker;
        _dataSource = dataSource;
    }


    public IResult<IGetManufacturersResponce> Run()
    {
        _dataStateTracker.DisableTracking();
        IGetManufacturersResponce responce = new GetManufacturersResponce
        (
            _dataSource.Get<BusinessModel::CarManufacturer>()
                       .Select(manufacturer => new ManufacturerDTO(
                           manufacturer.Id,
                           manufacturer.Name)
                       )
                       .ToList()
        ); 

        _filteringService[typeof(GetManufacturersFilters)]
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }

}