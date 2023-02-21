namespace Domain.Entities;

public class CarOwnership
{
    public Guid OwnerId
    {
        get => Owner.Id;
        private set { }
    }
    public User Owner { get; private set; }

    public Guid CarId
    {
        get => Car.Id;
        private set { }
    }
    public Car Car { get; private set; }


    public CarOwnership()
    {
        Owner = new();
        Car = new();
    }

    public CarOwnership(User owner, Car car)
    {
        Owner = owner;
        Car = car;
    }

}