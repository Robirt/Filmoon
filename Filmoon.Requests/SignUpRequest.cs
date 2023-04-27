namespace Filmoon.Requests;

public class SignUpRequest
{
    public SignUpRequest()
    {
        
    }

    public SignUpRequest(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
