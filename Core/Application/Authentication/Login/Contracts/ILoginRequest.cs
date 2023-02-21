namespace Application.Authentication.Login.Contracts;

public interface ILoginRequest
{
    public string Email { get; init; }
    public string Password { get; init; }

}
