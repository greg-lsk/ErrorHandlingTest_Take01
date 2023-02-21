using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Filtering;

internal class SubjectCollection
{
    private readonly TypedData _primaryUnit = new();
    private readonly List<IFilterable> _subjects = new();

    internal IEnumerable<IFilterable> Filterables
        => _subjects;


    internal void Add<TPrimary>(TPrimary primaryUnitData)
    {
        _primaryUnit.Update(typeof(TPrimary), primaryUnitData);
        BindToPrimary(null);
    }

    internal void Add(params object[] comparandUnitData)
    {
        foreach (var comparand in comparandUnitData)
        {
            BindToPrimary(comparand);
        }
    }


    private void BindToPrimary(object? comparand)
        => _subjects.Add(new Subject(_primaryUnit, comparand));

}