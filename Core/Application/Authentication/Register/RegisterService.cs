using Application.Authentication.Common.Responce;
using Application.Authentication.Register.Contracts;
using Application.Authentication.Register.Errors;
using ErrorHandler;


namespace Application.Authentication.Register;

internal class RegisterService : IRegisterService
{

    private readonly IRegisterQueries _queries;
    private readonly IFilteringService _filteringService;


    public RegisterService(IRegisterQueries queries,
                           IFilteringService filteringService)
    {
        _queries = queries;
        _filteringService = filteringService;
    }


    public IResult<IAuthenticationResponce> Run(IRegisterRequest request)
    {
        _filteringService[typeof(RegisterRequestFilters)]
            .Filter(request)
            .Using(_queries)
            .Run();

        if (_filteringService.Interrupted)
            return _filteringService.YieldResult<IAuthenticationResponce>(null);

        var response = _queries.AddUser(request);

        return _filteringService.YieldResult(response);
    }

}