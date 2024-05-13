namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public bool Error { get; set; } = true;
    public string Message { get; set; } = string.Empty;

    public ResponseErrorJson(string errorMessage)
    {
        Message = errorMessage;
    }
}
