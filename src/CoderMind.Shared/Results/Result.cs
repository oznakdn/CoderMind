
namespace CoderMind.Shared.Results;

public class Result : IResult
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; }
    public List<string> Errors { get; set; }

    protected Result() { }

    public static Result Success(string? message = null)
    {
        return new Result
        {
            Message = message ?? string.Empty,
            IsSuccess = true
        };
    }

    public static Result Failure(string? message = null, List<string>? errors = null)
    {
        return new Result
        {
            Message = message ?? string.Empty,
            Errors = errors ?? new(),
            IsSuccess = false
        };
    }
}


public class Result<T> : Result, IResult<T>
{
    public T? Value { get; set; }
    public List<T> Values { get; set; }

    public static Result<T> Success(T value, string? message = null)
    {
        return new Result<T>
        {
            Value = value,
            Message = message ?? string.Empty,
            IsSuccess = true
        };
    }

    public static Result<T> Success(List<T>? values, string? message = null)
    {
        return new Result<T>
        {
            Values = values ?? null,
            Message = message ?? string.Empty,
            IsSuccess = true
        };
    }
}
