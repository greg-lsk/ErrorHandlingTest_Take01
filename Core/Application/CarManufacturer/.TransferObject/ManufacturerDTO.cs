namespace Application.CarManufacturer.TransferObject;

public class ManufacturerDTO : IManufacturerDTO
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public ManufacturerDTO(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}