using Application.CarManufacturer.TransferObject;
using Application.CarManufacturer.GetManufacturers.Contracts;


namespace Application.CarManufacturer.GetManufacturers;

public class GetManufacturersResponce : IGetManufacturersResponce
{
    public IReadOnlyCollection<IManufacturerDTO> Manufacturers { get; private set; }

    public GetManufacturersResponce(IReadOnlyCollection<IManufacturerDTO> manufacturers)
    {
        Manufacturers = manufacturers;
    }
}