namespace Application.Car.TransferObject;

public interface ICarDTO
{
    public Guid CarId { get; }
    public string ModelName { get; }
}
