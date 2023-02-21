using Application.CarModel.TransferObject;


namespace Application.CarModel.GetModels.Contracts;

public interface IGetModelsResponce
{
    public IReadOnlyCollection<ICarModelDTO> Models { get; }
}