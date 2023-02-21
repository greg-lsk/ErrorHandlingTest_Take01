namespace Application.Car.TransferObject;

public class CarDTO : ICarDTO
{
    public Guid CarId { get; init; }
    public string ModelName { get; init; }


    public CarDTO(Guid carId, string modelName)
    {
        CarId = carId;
        ModelName = modelName;
    }

}