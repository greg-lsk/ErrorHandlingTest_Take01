using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Traversable;

internal interface ITraversable
{
    internal void TraverseWith(IEnumerable<IFilterable> subjects, IFilteringInfo infoForUpdate);
}