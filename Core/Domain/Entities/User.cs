using Domain.Abstractions;


namespace Domain.Entities;

public class User : Registerable
{
    public Guid Id { get; private set; }
    public IReadOnlyCollection<CarOwnership>? Cars { get; private set; }

    internal User() : base() 
    {
        Cars = new List<CarOwnership>();
    }

    public User(string email,
            string password)
    : base(email, password)
    {
        Cars = null;
    }

    public User(string email,
                string password,
                IReadOnlyCollection<CarOwnership> cars) 
    :base(email, password)
    {
        Cars = cars;
    }

}
