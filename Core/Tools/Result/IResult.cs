namespace ErrorHandler;

public interface IResult<TObject>
{
    public TObject? Body { get; }
    public Enum Description { get; }
    public bool IsError { get; }
    public bool IsSuccess { get; }

}