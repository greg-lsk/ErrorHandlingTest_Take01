using Application.Authentication.Common.Responce;
using Application.Authentication.Login.Contracts;
using ErrorHandler.Traversable;

namespace Application.Authentication.Login.Errors;

public sealed class LoginResponceFilters : FilterChain<IAuthenticationResponce>
{
    protected override Enum SuccessInfo { get; init; }

    public LoginResponceFilters()
    {
        SuccessInfo = LoginInfo.SuccessfulLogin;

        AddFilter(
            responce => responce == null,
            LoginInfo.UserNotFound);

        AddFilter<ILoginRequest>(
            (responce, request) => responce.Password != request.Password,
            LoginInfo.IncorrectPassword);
    }

}