using Application.Authentication.Common.Responce;
using ErrorHandler;

namespace Application.Authentication.Login.Contracts;

public interface ILoginService
{
    public IResult<IAuthenticationResponce> Run(ILoginRequest request);

}