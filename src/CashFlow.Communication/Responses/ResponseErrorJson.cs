namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public bool Error { get; set; } = true;
    public List<string> ErrorMessages { get; set; } = [];

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
