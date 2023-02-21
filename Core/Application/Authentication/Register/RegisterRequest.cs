using Application.Authentication.Register.Contracts;


namespace Application.Authentication.Register;

public class RegisterRequest : IRegisterRequest
{
    public string Email { get; init; }
    public string Password { get; init; }

    public RegisterRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

}