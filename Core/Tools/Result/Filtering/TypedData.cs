namespace ErrorHandler.Filtering;

internal class TypedData
{
    internal Type Type { get; private set; }
    internal object? Data { get; private set; }


    internal TypedData()
    {
        Type = typeof(object);
        Data = null;
    }

    internal TypedData(Type type, object? data)
    {
        Type = type;
        Data = data;
    }


    internal void Update(Type type, object? data)
    {
        Type = type;
        Data = data;
    }

}
