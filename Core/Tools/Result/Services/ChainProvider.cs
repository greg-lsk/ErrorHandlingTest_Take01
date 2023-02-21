using ErrorHandler.Traversable;
using ErrorHandler.Utills;


namespace ErrorHandler.Services;

public class ChainProvider
{

    private readonly Dictionary<Type, ITraversable> _filterChains = new();

    internal ITraversable this[Type index]
        => _filterChains[index];

    public ChainProvider()
    {
        new AssemblyScanner().Run(_filterChains);
    }

}