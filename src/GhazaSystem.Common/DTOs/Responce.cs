namespace GhazaSystem.Common.DTOs;

public class Response<T>
{
    public int StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public List<string>? Errors { get; set; }
    public string? Message { get; set; }

    public T? Data { get; set; }


}

public static class ResponseBuilder
{
    #region seccess responce

    public static Response<T> Success<T>(T data, bool seccess = true, int status = 200, string message = "عملیات با موفقیت انجام شد.")
    {
        return new Response<T>
        {
            StatusCode = status,
            IsSuccess = seccess,
            Message = message,
            Data = data
        };
    }
    public static Response<object> Success(bool seccess = true, int status = 200, string message = "عملیات با موفقیت انجام شد.")
    {
        return new Response<object>
        {
            StatusCode = status,
            IsSuccess = seccess,
            Message = message
        };
    }
    #endregion

    #region failure responce
    public static Response<T> Failure<T>(bool seccess = false, int status = 400, string message = "عملیات با شکست مواجه شد.", List<string>? errors = null)
    {
        return new Response<T>
        {
            StatusCode = status,
            IsSuccess = seccess,
            Message = message,
            Errors = errors ?? new List<string>()
        };
    }

    public static Response<object> Failure(bool seccess = false, int status = 400, string message = "عملیات با شکست مواجه شد.", List<string>? errors = null)
    {
        return new Response<object>
        {
            StatusCode = status,
            IsSuccess = seccess,
            Message = message,
            Errors = errors ?? new List<string>()
        };
    }
    #endregion 

}
