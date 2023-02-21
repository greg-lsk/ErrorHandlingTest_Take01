namespace Domain.Entities;

public class CarManufacturer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<CarModel> Models { get; private set; }


    internal CarManufacturer()
    {
        Name = string.Empty;
        Models = new List<CarModel>();
    }

    public CarManufacturer(string name,
                           IReadOnlyCollection<CarModel> models)
    {
        Name = name;
        Models = models;
    }

}