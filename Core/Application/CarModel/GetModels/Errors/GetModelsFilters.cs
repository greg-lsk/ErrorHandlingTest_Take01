using Application.CarModel.GetModels.Contracts;
using ErrorHandler.Traversable;


namespace Application.CarModel.GetModels.Errors;

public class GetModelsFilters : FilterChain<IGetModelsResponce>
{
    protected override Enum SuccessInfo { get; init; }


	public GetModelsFilters()
	{
		SuccessInfo = GetModelsInfo.SuccessfulExecusion;

		AddFilter(
			responce => responce == null,
			GetModelsInfo.InternalServerError);

		AddFilter(
			responce => responce.Models.Count == 0,
			GetModelsInfo.NoModelsRegistered);
	}

}