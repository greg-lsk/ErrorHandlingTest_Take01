using Application.Authentication.Register.Contracts;
using ErrorHandler.Traversable;


namespace Application.Authentication.Register.Errors;

public sealed class RegisterRequestFilters : FilterChain<IRegisterRequest>
{
    protected override Enum SuccessInfo { get; init; }

    public RegisterRequestFilters()
    {
        SuccessInfo = RegisterInfo.SuccessfulRequestValidation;

        AddFilter(
            request => request.Email == string.Empty,
            RegisterInfo.NoEmailProvided);

        AddFilter(
            request => request.Email.Length > 9,
            RegisterInfo.InvalidEmailFormat);

        AddFilter(
            request => request.Password == string.Empty,
            RegisterInfo.NoPasswordProvided);

        AddFilter(
            request => request.Password.Length > 9,
            RegisterInfo.InvalidPasswordFormat);

        AddFilter<IRegisterQueries>(
            (request, queries) => queries.UserExists(request),
            RegisterInfo.UserAlreadyExists);
    }

}