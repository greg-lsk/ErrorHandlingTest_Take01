namespace ErrorHandler.Filtering.Contracts;

internal interface IFilteringInfo
{
    internal Enum Description { get; }
    internal bool FilterActivated { get; }

    internal void FilteringSuccess(Enum successDescription);
    internal void FilteringFailure(Enum activatedFilterInfo);
}