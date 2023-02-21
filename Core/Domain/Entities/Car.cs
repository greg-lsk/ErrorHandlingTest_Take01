namespace Domain.Entities;

public class Car
{
    public Guid Id { get; private set; }
    public CarModel? Model { get; private set; }
    public IReadOnlyCollection<CarOwnership> Owners { get; private set; }


    public Car()
    {
        Model = new();
        Owners = new List<CarOwnership>();
    }

    public Car(CarModel model)
    {
        Model = model;
        Owners = new List<CarOwnership>();
    }

    public string ModelName
        => Model != null ? Model.Name : string.Empty;
}