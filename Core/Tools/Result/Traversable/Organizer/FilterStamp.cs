using ErrorHandler.Filtering.Contracts;


namespace ErrorHandler.Traversable.Organizer;

internal sealed class FilterStamp : IClusterId
{
    public Type PrimaryID { get; private set; }
    public Type? ComparandID { get; private set; }


    internal FilterStamp(Type primary)
    {
        PrimaryID = primary;
        ComparandID = null;
    }

    internal FilterStamp(Type primary, Type comparand)
    {
        PrimaryID = primary;
        ComparandID = comparand;
    }

    public override bool Equals(object? obj)
    {
        var stamp = obj as FilterStamp;

        if (stamp == null)
            return false;

        return ComparandID != null
            ? PrimaryID.Equals(stamp.PrimaryID)
                && ComparandID.Equals(stamp.ComparandID)
            : PrimaryID.Equals(stamp.PrimaryID);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PrimaryID, ComparandID);
    }

}