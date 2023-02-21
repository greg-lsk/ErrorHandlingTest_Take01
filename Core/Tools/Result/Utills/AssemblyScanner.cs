using ErrorHandler.Traversable;


namespace ErrorHandler.Utills;

internal class AssemblyScanner
{
    internal void Run(Dictionary<Type, ITraversable> chains)
    {
        foreach (var chainType in TypeScan(typeof(FilterChain<>)))
        {
            var chain = Activator.CreateInstance(chainType);
            chains.Add(chainType, (ITraversable)chain);
        }
    }


    private List<Type> TypeScan(Type type)
    {
        var types = new List<Type>();

        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var foundTypes = assembly.GetTypes().Where(t =>
                t.BaseType != null
                && t.BaseType.IsGenericType
                && t.BaseType.GetGenericTypeDefinition() == type);

            types.AddRange(foundTypes);
        }

        return types;
    }

}