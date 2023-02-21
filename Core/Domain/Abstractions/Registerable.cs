namespace Domain.Abstractions;

public abstract class Registerable
{
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;


    protected Registerable() { }

    protected Registerable(string emain, string password)
    {
        Email = emain;
        Password = password;
    }
}
