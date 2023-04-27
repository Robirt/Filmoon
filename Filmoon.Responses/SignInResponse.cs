namespace Filmoon.Responses;

public class SignInResponse : ActionResponse
{
    public SignInResponse(bool succeeded, string message) : base(succeeded, message) {}

    public SignInResponse(bool succeeded, string message, string token) : base(succeeded, message)
    {
        Token = token;
    }

    public string Token { get; set; } = string.Empty;
}
