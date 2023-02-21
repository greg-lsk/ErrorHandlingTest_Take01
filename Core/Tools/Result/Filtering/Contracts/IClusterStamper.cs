namespace ErrorHandler.Filtering.Contracts;

internal interface IClusterStamper
{
    internal IClusterId Stamp(IFilter toStamp);
}