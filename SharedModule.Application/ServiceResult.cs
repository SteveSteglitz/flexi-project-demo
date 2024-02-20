namespace SharedModule.Application;

public enum ServiceResultType
{
    Success,
    Fail,
    NotFound
}

public class ServiceResult<T>
{
    public ServiceResultType ResultType { get; }
    public T Data { get; }
    public List<string> Errors { get; }

    private ServiceResult(ServiceResultType resultType, T data, List<string> errors)
    {
        ResultType = resultType;
        Data = data;
        Errors = errors;
    }

    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T>(ServiceResultType.Success, data, null);
    }
    
    // public static ServiceResult<IEnumerable<T>> Success(IEnumerable<T> data)
    // {
    //     return new ServiceResult<IEnumerable<T>>(ServiceResultType.Success, data, null);
    // }
    
    public static ServiceResult<T> Fail(List<string> errors)
    {
        return new ServiceResult<T>(ServiceResultType.Fail, default(T), errors);
    }

    public static ServiceResult<T> Fail(string error)
    {
        return Fail(new List<string> { error });
    }
    
    // public static ServiceResult<IEnumerable<T>> Fail(List<string> errors)
    // {
    //     return new ServiceResult<IEnumerable<T>>(ServiceResultType.Fail, default(IEnumerable<T>), errors);
    // }
    //
    // public static ServiceResult<IEnumerable<T>> Fail(string error)
    // {
    //     return Fail(new List<string> { error });
    // }


    public static ServiceResult<T> NotFound()
    {
        return new ServiceResult<T>(ServiceResultType.NotFound, default(T), null);
    }
}