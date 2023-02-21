using Application.Authentication.Common.Responce;


namespace Application.Authentication.Login.Contracts;

public interface ILoginQueries
{
    public IAuthenticationResponce? GetUser(ILoginRequest request);

}