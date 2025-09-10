namespace ERP.Shared.Common.ResultPattern;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public List<string>? Errors { get; set; }
    public T? Data { get; set; }


    public static Result<T> Success(T? data , string? message = null)
    {
        message ??= "OK";
        return new Result<T>
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };
    }
    public static Result<T> Error(string? message = null)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Message = message,
        };
    }
    public static Result<T> Error(List<string>? errors = null)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Errors = errors,
        };
    }
    public static Result<T> Error()
    {
        return new Result<T>
        {
            IsSuccess = false
        };
    }
}
class Result : Result<string> { }
