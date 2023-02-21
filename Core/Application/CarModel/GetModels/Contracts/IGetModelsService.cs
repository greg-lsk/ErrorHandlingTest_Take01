using ErrorHandler;
using Application.GuidRequest;


namespace Application.CarModel.GetModels.Contracts;

public interface IGetModelsService
{
    public IResult<IGetModelsResponce> Run(IGuidRequest request);
}