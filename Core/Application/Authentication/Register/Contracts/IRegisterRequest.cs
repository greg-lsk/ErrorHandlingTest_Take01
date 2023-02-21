namespace Application.Authentication.Register.Contracts;

public interface IRegisterRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}
