namespace Application.CarModel.TransferObject;

public interface ICarModelDTO
{
    public Guid Id { get; }
    public string Name { get; }
    public string ProductionPeriod { get; }
}