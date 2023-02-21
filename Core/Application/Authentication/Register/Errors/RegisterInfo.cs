namespace Application.Authentication.Register.Errors;

public enum RegisterInfo
{
    InvalidEmailFormat,
    NoEmailProvided,
    NoPasswordProvided,
    InvalidPasswordFormat,
    SuccessfulRequestValidation,

    UserAlreadyExists,
    SuccessfulRegistration
}
