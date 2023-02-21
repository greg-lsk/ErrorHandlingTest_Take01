using Application.Authentication.Login.Contracts;
using ErrorHandler.Traversable;


namespace Application.Authentication.Login.Errors;

public sealed class LoginRequestFilters : FilterChain<ILoginRequest>
{
    protected override Enum SuccessInfo { get; init; }

    public LoginRequestFilters()
    {
        SuccessInfo = LoginInfo.SuccessfulRequestValidation;

        AddFilter(
            request => request.Email == string.Empty,
            LoginInfo.NoEmailProvided);

        AddFilter(
            request => request.Password == string.Empty,
            LoginInfo.NoPasswordProvided);
    }

}
