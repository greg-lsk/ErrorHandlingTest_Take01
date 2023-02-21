using Queries.DataAccess;
using Application.CarManufacturer.TransferObject;
using Application.CarManufacturer.GetManufacturers;
using Application.CarManufacturer.GetManufacturers.Contracts;


namespace Queries.CarManufacturer;

internal class GetManufacturersQueries : DatabaseQuery, IGetManufacturersQueries
{
    public GetManufacturersQueries(IDataAccessor accessor) : base(accessor){}


    public IGetManufacturersResponce? GetManufacturers()
    {
        var responce = _accessor.Manufacturers
            .Select(manufacturer => new ManufacturerDTO(
                manufacturer.Id,
                manufacturer.Name)
            )
            .ToList();

        return new GetManufacturersResponce(responce);
    }
}