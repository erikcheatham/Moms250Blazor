namespace Moms250Blazor.Common;

[Serializable]
public class ServiceResult<T>
{
    private readonly List<string> _errors = [];
    public T Data { get; set; }

    public bool Success { get; set; }

    public string Message { get; set; }

    public string ErrorID { get; set; }

    public List<string> Errors
    {
        get
        {
            return _errors;
        }
    }

    public ServiceResult() : this(default!, false, null!, null!, null!) { }

    public ServiceResult(T data, bool success) : this(data, success, null!, null!, null!) { }

    public ServiceResult(T data, bool success, string message, string errorID, IEnumerable<string> errors)
    {
        Data = data;
        Success = success;
        Message = message;
        ErrorID = errorID;
        if (errors != null)
            _errors.AddRange(errors);

    }
}
