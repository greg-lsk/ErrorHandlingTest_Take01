using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering;

internal class Result<TObject> : IResult<TObject>
    where TObject : class
{
    internal IFilteringInfo Info { get; init; }
    public TObject? Body { get; private set; } = null;

    public bool IsSuccess => !Info.FilterActivated;
    public bool IsError => !IsSuccess;
    public Enum Description => Info.Description;


    internal Result(TObject? forObject, IFilteringInfo info)
    {
        Body = forObject;
        Info = info;
    }

}