using Application.Authentication.Common.Responce;
using Application.Authentication.Register.Contracts;
using Microsoft.EntityFrameworkCore;
using Queries.DataAccess;

namespace Queries.Authentication;

internal class RegisterQueries : DatabaseQuery, IRegisterQueries
{

    public RegisterQueries(IDataAccessor accessor) : base(accessor) { }


    public IAuthenticationResponce? AddUser(IRegisterRequest request)
    {

        var added = _accessor.Users.Add(new(request.Email, request.Password));
        _accessor.SaveChanges();

        return (AuthenticationResponce?)added.Entity;
    }

    public bool UserExists(IRegisterRequest request)
    {
        return _accessor.Users
            .AsNoTracking()
            .Any(user => user.Email == request.Email);
    }

    public bool UserExists(Guid userId)
    {
        return _accessor.Users
            .AsNoTracking()
            .Any(user => user.Id == userId);
    }
}