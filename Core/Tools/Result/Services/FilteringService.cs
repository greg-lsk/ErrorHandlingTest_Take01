using ErrorHandler.Filtering;
using ErrorHandler.Traversable;


namespace ErrorHandler.Services;

public class FilteringService : IFilteringService
{

    private readonly ChainProvider _provider;

    private readonly SubjectCollection _subjects;
    private readonly FilteringInfo _info;
    private ITraversable _chain;

    public IFilteringService this[Type chainType]
    {
        get
        {
            _chain = _provider[chainType];
            return this;
        }
    }

    public bool Completed => !_info.FilterActivated;


    public FilteringService(ChainProvider provider)
    {
        _provider = provider;
        _subjects = new();
        _info = new();
    }


    public IFilteringService Using(params object[] comparands)
    {
        _subjects.Add(comparands);
        return this;
    }

    public IFilteringService Filter<TPrimary>(TPrimary primarySubject)
    {
        _subjects.Add(primarySubject);
        return this;
    }

    public IResult<TPrimary> YieldResult<TPrimary>(TPrimary? resultBody)
    where TPrimary : class
    {
        return ResultProducer(resultBody);
    }


    public IFilteringService Run()
    {
        _chain.TraverseWith(
            _subjects.Filterables,
            _info);

        return this;
    }


    private IResult<TPrimary> ResultProducer<TPrimary>(TPrimary? body)
    where TPrimary : class
    {
        return new Result<TPrimary>(body, _info);
    }

}