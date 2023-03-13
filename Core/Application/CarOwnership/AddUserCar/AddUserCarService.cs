using BusinessModel = Domain.Entities;
using Application.DataSource;
using Application.CarOwnership.AddUserCar.Contracts;


namespace Application.CarOwnership.AddUserCar;

public class AddUserCarService : IAddUserCarService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;


    public AddUserCarService(IDataSource dataSource,
                             IDataStateTracker dataStateTracker)
    {
        _dataSource = dataSource;
        _dataStateTracker = dataStateTracker;
    }


    public void Run(IAddUserCarRequest request)
    {
        var user = _dataSource.Get<BusinessModel::User>()
                              .Where(user => user.Id == request.UserId)
                              .FirstOrDefault();

        var carModel = _dataSource.Get<BusinessModel::CarModel>()
                                  .Where(model => model.Id == request.ModelId)
                                  .FirstOrDefault();

        var car = _dataSource.Add<BusinessModel::Car>(new(carModel));

        _dataSource.Add<BusinessModel::CarOwnership>(new(user, car));

        _dataStateTracker.ApplyChanges();
    }

}