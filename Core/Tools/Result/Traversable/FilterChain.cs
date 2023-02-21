using ErrorHandler.Filtering.Contracts;
using ErrorHandler.Filtering.Types;
using ErrorHandler.Traversable.Organizer;


namespace ErrorHandler.Traversable;

public abstract class FilterChain<TPrimary> : ITraversable
    where TPrimary : class
{
    protected abstract Enum SuccessInfo { get; init; }

    private readonly ClusterSet _filterClusters = new();


    void ITraversable.TraverseWith(IEnumerable<IFilterable> subjectsForFiltering,
                                   IFilteringInfo info)
    {
        foreach (var subject in subjectsForFiltering)
        {
            _filterClusters.ApplyFiltersTo(
                subject,
                info);

            if (info.FilterActivated)
                return;
        }

        info.FilteringSuccess(SuccessInfo);
    }

    protected void AddFilter(Func<TPrimary, bool> rule,
                             Enum info)
    {
        var filter = new Rule(
            (x) => rule((TPrimary)x),
            info);

        _filterClusters.Register(filter);
    }

    protected void AddFilter<TComparand>(Func<TPrimary, TComparand, bool> comparator,
                                         Enum info)
    {
        var filter = new Comparator(
            (x, y) => comparator((TPrimary)x, (TComparand)y),
            info);

        _filterClusters.Register(filter);
    }

}