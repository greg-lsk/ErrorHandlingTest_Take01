using ErrorHandler;
using Application.GuidRequest;
using Application.CarModel.GetModels.Errors;
using Application.CarModel.GetModels.Contracts;


namespace Application.CarModel.GetModels;

internal class GetModelsService : IGetModelsService
{
    private readonly IGetModelsQueries _queries;
    private readonly IFilteringService _filteringService;


    public GetModelsService(IGetModelsQueries queries,
                            IFilteringService filteringService)
    {
        _queries = queries;
        _filteringService = filteringService;
    }


    public IResult<IGetModelsResponce> Run(IGuidRequest request)
    {
        var responce = _queries.GetModelsOfManufacturer(request);

        _filteringService[typeof(GetModelsFilters)]
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }
}