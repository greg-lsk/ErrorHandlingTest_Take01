namespace ErrorHandler.Filtering.Contracts;

internal interface IFilter
{
    internal Delegate Filter { get; }
    internal Enum Info { get; }

    internal bool Catches(IFilterable filtered);
}