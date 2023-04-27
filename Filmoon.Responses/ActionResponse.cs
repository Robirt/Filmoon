namespace Filmoon.Responses;

public class ActionResponse
{
    public ActionResponse(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
    }

    public bool Succeeded { get; init; }

    public string Message { get; init; }
}
