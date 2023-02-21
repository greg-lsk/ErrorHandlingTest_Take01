namespace ErrorHandler.Filtering.Contracts;

internal interface IClusterId
{
    internal Type PrimaryID { get; }
    internal Type? ComparandID { get; }

    internal bool ClustersRules => ComparandID == null;
    internal bool ClustersCompares => ComparandID != null;

    public bool Equals(object? obj);
    public int GetHashCode();

}