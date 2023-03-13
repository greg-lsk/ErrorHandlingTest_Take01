using ErrorHandler;
using BusinessModel = Domain.Entities;
using Application.DataSource;
using Application.Authentication.Common.Responce;
using Application.Authentication.Login.Contracts;
using Application.Authentication.Login.Errors;


namespace Application.Authentication.Login;

internal class LoginService : ILoginService
{
    private readonly IDataSource _dataSource;
    private readonly IDataStateTracker _dataStateTracker;
    private readonly IFilteringService _filteringService;


    public LoginService(IDataSource dataSource,
                        IDataStateTracker dataStateTracker,
                        IFilteringService service)
    {
        _filteringService = service;
        _dataStateTracker = dataStateTracker;
        _dataSource = dataSource;
    }


    public IResult<IAuthenticationResponce> Run(ILoginRequest request)
    {
        _filteringService[typeof(LoginRequestFilters)]
            .Filter(request)
            .Run();

        if (_filteringService.Interrupted)
            return _filteringService.YieldResult<IAuthenticationResponce>(null);

        _dataStateTracker.DisableTracking();
        IAuthenticationResponce? responce = (AuthenticationResponce?) _dataSource
            .Get<BusinessModel::User>()
            .FirstOrDefault(user => user.Email == request.Email);

        _filteringService[typeof(LoginResponceFilters)]
            .Using(request)
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }

}