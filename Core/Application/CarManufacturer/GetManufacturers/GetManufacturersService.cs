using ErrorHandler;
using Application.CarManufacturer.GetManufacturers.Errors;
using Application.CarManufacturer.GetManufacturers.Contracts;


namespace Application.CarManufacturer.GetManufacturers;

internal class GetManufacturersService : IGetManufacturersService
{
    private readonly IGetManufacturersQueries _queries;
    private readonly IFilteringService _filterService;


    public GetManufacturersService(IGetManufacturersQueries queries,
                                   IFilteringService filterService)
    {
        _queries = queries;
        _filterService = filterService;
    }


    public IResult<IGetManufacturersResponce> Run()
    {
        var responce = _queries.GetManufacturers();

        _filterService[typeof(GetManufacturersFilters)]
            .Filter(responce)
            .Run();

        return _filterService.YieldResult(responce);
    }

}