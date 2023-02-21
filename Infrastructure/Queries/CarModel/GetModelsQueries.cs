using Queries.DataAccess;
using Application.GuidRequest;
using Application.CarModel.TransferObject;
using Application.CarModel.GetModels;
using Application.CarModel.GetModels.Contracts;
using Microsoft.EntityFrameworkCore;


namespace Queries.CarModel;

internal class GetModelsQueries : DatabaseQuery ,IGetModelsQueries
{
    public GetModelsQueries(IDataAccessor accessor) : base(accessor){}

    public IGetModelsResponce? GetModelsOfManufacturer(IGuidRequest request)
    {
        var result = _accessor.Models
            .AsNoTracking()
            .Where(model => model.Manufacturer.Id == request.Id)
            .Select(model => new CarModelDTO(
                model.Id,
                model.Name,
                $"{model.ProductionPeriod}")
            )
            .ToList();

        return new GetModelsResponce(result);
    }
}