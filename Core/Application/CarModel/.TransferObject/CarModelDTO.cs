namespace Application.CarModel.TransferObject;

public class CarModelDTO : ICarModelDTO
{
    public Guid Id { get; init; }

    public string Name { get; init; }

    public string ProductionPeriod { get; init; }


    public CarModelDTO(Guid id,
                       string name,
                       string productionPeriod)
    {
        Id = id;
        Name = name;
        ProductionPeriod = productionPeriod;
    }

}