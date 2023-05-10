using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Generators;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class UsersService
{
    public UsersService(UsersRepository usersRepository)
    {
        UsersRepository = usersRepository;
    }

    private UsersRepository UsersRepository { get; }

    public async Task<SignInResponse> SignInAsync(SignInRequest userSignInRequest)
    {
        var user = await UsersRepository.GetByUserNameAsync(userSignInRequest.UserName);

        if (user is null) return new SignInResponse(false, $"User with name {userSignInRequest.UserName} doest not exists.");

        if (PasswordGenerator.GenerateHash(userSignInRequest.Password, user.PasswordSalt) != user.PasswordHash) return new SignInResponse(false, $"Invalid password.");

        return new SignInResponse(true, "User was signed in successful.", JwtBearerGenerator.GenerateJwtBearer(user.Id, user.UserName, user.Role!.Name));
    }
}
