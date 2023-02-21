using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering;

internal class Subject : IFilterable
{
    private readonly TypedData _primaryUnit;
    private readonly TypedData _comparandUnit;

    public Type PrimaryType => _primaryUnit.Type;
    public object? PrimaryData => _primaryUnit.Data;

    public Type ComparandType => _comparandUnit.Type;
    public object? ComparandData => _comparandUnit.Data;


    internal Subject(TypedData primary, object? comparand)
    {
        _primaryUnit = primary;

        var comparandType = comparand != null ? comparand.GetType() : typeof(object);
        _comparandUnit = new(comparandType, comparand);
    }

}