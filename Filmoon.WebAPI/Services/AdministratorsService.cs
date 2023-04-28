using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Generators;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class AdministratorsService
{
    public AdministratorsService(AdministratorsRepository administratorsRepository, UsersRepository usersRepository)
    {
        AdministratorsRepository = administratorsRepository;
        UsersRepository = usersRepository;
    }

    private AdministratorsRepository AdministratorsRepository { get; }
    private UsersRepository UsersRepository { get; }

    public async Task<ActionResponse> AddAsync(SignUpRequest userSignUpRequest)
    {
        if (await UsersRepository.GetByUserNameAsync(userSignUpRequest.UserName) is not null) return new ActionResponse(false, $"User with name {userSignUpRequest.UserName} already exists.");

        var passwordSalt = PasswordGenerator.GenerateSalt();
        var passwordHash = PasswordGenerator.GenerateHash(userSignUpRequest.Password, passwordSalt);

        try
        {
            await AdministratorsRepository.AddAsync(new AdministratorEntity() { UserName = userSignUpRequest.UserName, Email = userSignUpRequest.Email, PasswordSalt = passwordSalt, PasswordHash = passwordHash, RoleId = 1 });

            return new ActionResponse(true, $"Administrator {userSignUpRequest.UserName} was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Administrator {userSignUpRequest.UserName} was not added successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
