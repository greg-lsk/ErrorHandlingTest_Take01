using Application.CarManufacturer.TransferObject;


namespace Application.CarManufacturer.GetManufacturers.Contracts;

public interface IGetManufacturersResponce
{
    public IReadOnlyCollection<IManufacturerDTO> Manufacturers { get; }

}