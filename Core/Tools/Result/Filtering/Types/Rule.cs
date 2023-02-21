using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering.Types;

internal sealed class Rule : IFilter
{
    private readonly Func<object, bool> _rule;

    public Delegate Filter => _rule;
    public Enum Info { get; private set; }


    internal Rule(Func<object, bool> rule, Enum info)
    {
        _rule = rule;
        Info = info;
    }


    bool IFilter.Catches(IFilterable filtered)
    {
        if (!_rule(filtered.PrimaryData))
            return false;

        return true;
    }

}