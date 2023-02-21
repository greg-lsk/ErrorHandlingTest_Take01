using ErrorHandler;


namespace Application.CarManufacturer.GetManufacturers.Contracts;

public interface IGetManufacturersService
{
    public IResult<IGetManufacturersResponce> Run();
}