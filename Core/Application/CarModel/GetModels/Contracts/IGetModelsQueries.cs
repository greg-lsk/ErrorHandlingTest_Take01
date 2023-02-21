using Application.GuidRequest;


namespace Application.CarModel.GetModels.Contracts;

public interface IGetModelsQueries
{
    IGetModelsResponce? GetModelsOfManufacturer(IGuidRequest request);
}