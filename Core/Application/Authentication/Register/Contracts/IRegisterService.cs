using Application.Authentication.Common.Responce;
using ErrorHandler;

namespace Application.Authentication.Register.Contracts;

public interface IRegisterService
{
    public IResult<IAuthenticationResponce> Run(IRegisterRequest request);

}
