using ErrorHandler.Filtering.Contracts;
using ErrorHandler.Filtering.Types;


namespace ErrorHandler.Traversable.Organizer;

internal class FilterStamper : IClusterStamper
{
    public IClusterId Stamp(IFilter toStamp)
    {
        switch (toStamp)
        {
            case Rule:
                return new FilterStamp(
                    GetFilterType(toStamp, 0));
            case Comparator:
                return new FilterStamp(
                    GetFilterType(toStamp, 0),
                    GetFilterType(toStamp, 1));
            default:
                return null;
        }
    }

    private Type GetFilterType(IFilter filter, int index)
        => filter.Filter.Method.GetParameters()[index].ParameterType;

}
