namespace ErrorHandler.Filtering.Contracts;

internal interface IFilterable
{
    internal Type PrimaryType { get; }
    internal object? PrimaryData { get; }
    internal Type ComparandType { get; }
    internal object? ComparandData { get; }

    internal bool IsEligibleForNullCheck =>
        PrimaryData == null;

    internal bool IsEligibleForComparison =>
        PrimaryData != null
        && ComparandData != null;

    internal bool IsEligibleForRuleCheck =>
        PrimaryData != null
        && ComparandData == null;

}