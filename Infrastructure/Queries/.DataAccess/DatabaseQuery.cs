namespace Queries.DataAccess;

internal abstract class DatabaseQuery
{
    protected readonly IDataAccessor _accessor;

    protected DatabaseQuery(IDataAccessor accessor)
    {
        _accessor = accessor;
    }
}