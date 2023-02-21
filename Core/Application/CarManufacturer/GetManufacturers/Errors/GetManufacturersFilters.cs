using ErrorHandler.Traversable;
using Application.CarManufacturer.GetManufacturers.Contracts;


namespace Application.CarManufacturer.GetManufacturers.Errors;

public class GetManufacturersFilters : FilterChain<IGetManufacturersResponce>
{
    protected override Enum SuccessInfo { get; init; }


	public GetManufacturersFilters()
	{
		SuccessInfo = GetManufacturersInfo.SuccessfulExecution;

		AddFilter(responce => responce == null,
			GetManufacturersInfo.InternalServerError);

		AddFilter(responce => responce.Manufacturers.Count == 0,
			GetManufacturersInfo.NoManufacturersFound);
    }
}