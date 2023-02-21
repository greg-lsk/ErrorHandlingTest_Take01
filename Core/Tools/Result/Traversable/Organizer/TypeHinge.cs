using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Traversable.Organizer;

internal class TypeHinge : IClusterHinge
{
    public IEnumerable<IClusterId> GetHingableClusters(IEnumerable<IClusterId> clusters,
                                                       IFilterable filterable)
    {
        return clusters.Where(clusterId => AreHingable(clusterId, filterable));
    }

    private bool AreHingable(IClusterId cluster, IFilterable filterable)
    {
        if (filterable.IsEligibleForNullCheck)
            return ArePrimaryHingable(cluster, filterable);


        if (cluster.ClustersRules && filterable.IsEligibleForRuleCheck)
            return ArePrimaryHingable(cluster, filterable);


        if (cluster.ClustersCompares && filterable.IsEligibleForComparison)
            return AreTotallyHingable(cluster, filterable);


        return false;
    }


    private bool ArePrimaryHingable(IClusterId cluster, IFilterable filterable)
        => cluster.PrimaryID.IsAssignableFrom(filterable.PrimaryType);
    private bool AreTotallyHingable(IClusterId cluster, IFilterable filterable)
        => cluster.PrimaryID.IsAssignableFrom(filterable.PrimaryType)
        && cluster.ComparandID.IsAssignableFrom(filterable.ComparandType);

}