using ErrorHandler;
using Domain.Entities;
using Application.DataSource;
using Application.Authentication.Common.Responce;
using Application.Authentication.Register.Contracts;
using Application.Authentication.Register.Errors;


namespace Application.Authentication.Register;

internal class RegisterService : IRegisterService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;
    private readonly IFilteringService _filteringService;


    public RegisterService(IDataSource dataSource,
                        IDataStateTracker dataStateTracker,
                        IFilteringService service)
    {
        _filteringService = service;
        _dataStateTracker = dataStateTracker;
        _dataSource = dataSource;
    }


    public IResult<IAuthenticationResponce> Run(IRegisterRequest request)
    {
        _dataStateTracker.DisableTracking();
        _filteringService[typeof(RegisterRequestFilters)]
            .Filter(request)
            .Using(_dataSource)
            .Run();

        if (_filteringService.Interrupted)
            return _filteringService.YieldResult<IAuthenticationResponce>(null);

        _dataStateTracker.EnableTracking();
        var user = new User(request.Email, request.Password);
        IAuthenticationResponce? response =
            (AuthenticationResponce?)_dataSource.Add(user);
        _dataStateTracker.ApplyChanges();

        return _filteringService.YieldResult(response);
    }

}