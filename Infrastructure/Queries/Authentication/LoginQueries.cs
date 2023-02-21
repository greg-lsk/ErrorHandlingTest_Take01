using Application.Authentication.Common.Responce;
using Application.Authentication.Login.Contracts;
using Microsoft.EntityFrameworkCore;
using Queries.DataAccess;


namespace Queries.Authentication;

internal class LoginQueries : DatabaseQuery, ILoginQueries
{

    public LoginQueries(IDataAccessor accessor) : base(accessor) { }


    public IAuthenticationResponce? GetUser(ILoginRequest request) => (AuthenticationResponce?) 
        _accessor.Users
            .AsNoTracking()
            .FirstOrDefault(user => user.Email == request.Email);
}