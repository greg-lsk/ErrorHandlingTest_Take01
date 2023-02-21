namespace Application.Authentication.Login.Errors;

public enum LoginInfo
{
    NoEmailProvided,
    NoPasswordProvided,
    SuccessfulRequestValidation,

    UserNotFound,
    IncorrectPassword,
    SuccessfulLogin
}