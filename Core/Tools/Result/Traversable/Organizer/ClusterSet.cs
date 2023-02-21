using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Traversable.Organizer;

internal class ClusterSet
{
    private readonly Dictionary<IClusterId, ICollection<IFilter>> _clusters;
    private readonly IClusterStamper _stamper;
    private readonly IClusterHinge _hinge;


    public ClusterSet()
    {
        _clusters = new();
        _stamper = new FilterStamper();
        _hinge = new TypeHinge();
    }


    internal void ApplyFiltersTo(IFilterable filterable,
                                 IFilteringInfo info)
    {
        var stamps = _hinge.GetHingableClusters(
            _clusters.Keys,
            filterable);

        foreach (var stamp in stamps)
        {
            TraverseCluster(
                _clusters[stamp],
                filterable,
                info);

            if (info.FilterActivated)
                return;
        }
    }
    private void TraverseCluster(ICollection<IFilter> filterCluster,
                                 IFilterable subject,
                                 IFilteringInfo info)
    {
        foreach (var filter in filterCluster)
        {
            if (filter.Catches(subject))
            {
                info.FilteringFailure(filter.Info);
                return;
            }
        }
    }

    internal void Register(IFilter filter)
    {
        var clusterStamp = _stamper.Stamp(filter);

        if (_clusters.ContainsKey(clusterStamp))
        {
            _clusters[clusterStamp].Add(filter);
            return;
        }

        _clusters.Add(
            clusterStamp,
            new List<IFilter> { filter });
    }

}