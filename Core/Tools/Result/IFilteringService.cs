namespace ErrorHandler;

public interface IFilteringService
{
    public IFilteringService this[Type chainType] { get; }

    public IFilteringService Using(params object[] comparands);
    public IFilteringService Filter<TPrimary>(TPrimary primarySubject);
    public IFilteringService Run();
    public IResult<TBody> YieldResult<TBody>(TBody? resultBody)
        where TBody : class;

    public bool Completed { get; }
    public bool Interrupted => !Completed;
}
