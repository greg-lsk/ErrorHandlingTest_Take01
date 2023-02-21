using Domain.ValueTypes;


namespace Domain.Entities;

public class CarModel
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public CarManufacturer Manufacturer { get; private set; }
    public Period ProductionPeriod { get; private set; }
    public IReadOnlyCollection<Car>? OfCars { get; private set; }

    public bool IsInProduction => ProductionPeriod.IsActive;


    public CarModel()
    {
        Name = string.Empty;
        Manufacturer = new();
        ProductionPeriod = new();
        OfCars = new List<Car>();
    }

    public CarModel(string name,
                CarManufacturer manufacturedBy,
                Period productionPeriod)
    {
        Name = name;
        Manufacturer = manufacturedBy;
        ProductionPeriod = productionPeriod;
        OfCars = null;
    }

    public CarModel(string name,
                    CarManufacturer manufacturedBy,
                    Period productionPeriod,
                    IReadOnlyCollection<Car> ofCars)
    {
        Name = name;
        Manufacturer = manufacturedBy;
        ProductionPeriod = productionPeriod;
        OfCars = ofCars;
    }

}