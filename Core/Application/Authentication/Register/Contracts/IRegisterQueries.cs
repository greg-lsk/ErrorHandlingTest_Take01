using Application.Authentication.Common.Responce;


namespace Application.Authentication.Register.Contracts;

public interface IRegisterQueries
{
    public bool UserExists(Guid userId);
    public bool UserExists(IRegisterRequest request);
    public IAuthenticationResponce? AddUser(IRegisterRequest request);

}
