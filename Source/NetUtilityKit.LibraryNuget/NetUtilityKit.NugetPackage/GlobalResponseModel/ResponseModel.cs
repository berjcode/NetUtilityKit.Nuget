using System.Text.Json.Serialization;

namespace NetUtilityKit.NugetPackage.GlobalResponseModel;

public class ResponseModel<T>
{
    public T Result { get; private set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    [JsonIgnore]
    public int StatusCode { get; private set; }
    [JsonIgnore]
    public bool IsSuccessful { get; private set; }

    public static ResponseModel<T> SuccessResponse(T data, int statusCode)
    {
        return new ResponseModel<T> { Result = data, StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseModel<T> SuccessResponse(T data, int statusCode, string message)
    {
        return new ResponseModel<T> { Result = data, StatusCode = statusCode, Message = message, IsSuccessful = true };
    }
    public static ResponseModel<T> SuccessResponse(int statusCode)
    {
        return new ResponseModel<T> { Result = default(T), StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseModel<T> IsSuccessResponse(T Data, int statusCode, string message)
    {
        return new ResponseModel<T> { Result = default(T), Message = message, StatusCode = statusCode, IsSuccessful = true };
    }
    public static ResponseModel<T> ErrorResponse(List<string> errors, int statusCode)
    {
        return new ResponseModel<T> { Errors = errors, StatusCode = statusCode, IsSuccessful = false };
    }
    public static ResponseModel<T> ErrorResponse(string error, int statusCode)
    {
        return new ResponseModel<T> { Errors = new List<string>() { error }, StatusCode = statusCode, };
    }
}
