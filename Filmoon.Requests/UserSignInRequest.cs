namespace Filmoon.Requests
{
    public class UserSignInRequest
    {
        public UserSignInRequest()
        {

        }

        public UserSignInRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
