namespace ErrorHandler.Filtering.Contracts;

internal interface IClusterHinge
{
    internal IEnumerable<IClusterId> GetHingableClusters(
        IEnumerable<IClusterId> clusters,
        IFilterable filterable);
}