using Domain.Entities;


namespace Application.Authentication.Common.Responce;

public class AuthenticationResponce : IAuthenticationResponce
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }


    public AuthenticationResponce()
    {
        Id = Guid.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public AuthenticationResponce(Guid id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }


    public static explicit operator AuthenticationResponce?(User? user)
            => user != null ? new(user.Id, user.Email, user.Password) : null;

}