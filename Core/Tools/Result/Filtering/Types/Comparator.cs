using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering.Types;

internal sealed class Comparator : IFilter
{
    private readonly Func<object, object, bool> _comparator;

    public Delegate Filter => _comparator;
    public Enum Info { get; private set; }


    internal Comparator(Func<object, object, bool> comparator, Enum info)
    {
        _comparator = comparator;
        Info = info;
    }


    bool IFilter.Catches(IFilterable filtered)
    {
        if (!_comparator(filtered.PrimaryData, filtered.ComparandData))
            return false;

        return true;
    }

}