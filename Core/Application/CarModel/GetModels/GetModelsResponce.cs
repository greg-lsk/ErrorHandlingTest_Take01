using Application.CarModel.GetModels.Contracts;
using Application.CarModel.TransferObject;


namespace Application.CarModel.GetModels;

public class GetModelsResponce : IGetModelsResponce
{
    public IReadOnlyCollection<ICarModelDTO> Models { get; init; }


    public GetModelsResponce(IReadOnlyCollection<ICarModelDTO> models)
    {
        Models = models;
    }
}