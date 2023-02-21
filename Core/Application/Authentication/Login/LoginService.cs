using Application.Authentication.Common.Responce;
using Application.Authentication.Login.Contracts;
using Application.Authentication.Login.Errors;
using ErrorHandler;


namespace Application.Authentication.Login;

internal class LoginService : ILoginService
{

    private readonly ILoginQueries _queries;
    private readonly IFilteringService _filteringService;


    public LoginService(ILoginQueries queries,
                        IFilteringService service)
    {
        _queries = queries;
        _filteringService = service;
    }


    public IResult<IAuthenticationResponce> Run(ILoginRequest request)
    {
        _filteringService[typeof(LoginRequestFilters)]
            .Filter(request)
            .Run();

        if (_filteringService.Interrupted)
            return _filteringService.YieldResult<IAuthenticationResponce>(null);

        var responce = _queries.GetUser(request);

        _filteringService[typeof(LoginResponceFilters)]
            .Using(request)
            .Filter(responce)
            .Run();

        return _filteringService.YieldResult(responce);
    }

}