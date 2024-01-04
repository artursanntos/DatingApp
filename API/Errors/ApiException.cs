namespace API.Errors;

public class ApiException
{
    public ApiException(int statusCode, string message = null, string details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
    public int StatusCode { get; set; } // Status code
    public string Message { get; set; } // Error message
    public string Details { get; set; } // Stack trace
}
