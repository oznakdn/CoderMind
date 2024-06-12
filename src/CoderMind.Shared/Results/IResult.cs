namespace CoderMind.Shared.Results;

public interface IResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }

}


public interface IResult<T> : IResult
{
    public T Value { get; set; }
    public List<T> Values { get; set; }
}
