using Application.CarOwnership.AddUserCar.Contracts;


namespace Application.CarOwnership.AddUserCar;

public class AddUserCarService : IAddUserCarService
{
    private readonly IAddUserCarQueries _addUserCarQueries;


    public AddUserCarService(IAddUserCarQueries addUserCarQueries)
    {
        _addUserCarQueries = addUserCarQueries;
    }


    public void Run(IAddUserCarRequest request)
    {
        _addUserCarQueries.AddUserCar(request);
    }

}