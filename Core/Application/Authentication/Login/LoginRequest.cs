using Application.Authentication.Login.Contracts;


namespace Application.Authentication.Login;

public class LoginRequest : ILoginRequest
{
    public string Email { get; init; }
    public string Password { get; init; }

    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

}