using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering;

internal class FilteringInfo : IFilteringInfo
{
    public Enum Description { get; private set; }
    public bool FilterActivated { get; private set; }


    public FilteringInfo()
    {
        Description = null;
        FilterActivated = false;
    }

    public void FilteringSuccess(Enum successDescription)
    {
        Description = successDescription;
        FilterActivated = false;
    }

    public void FilteringFailure(Enum activatedFilterInfo)
    {
        Description = activatedFilterInfo;
        FilterActivated = true;
    }
}