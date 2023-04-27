using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Generators;
using Filmoon.WebAPI.Repositories;

namespace Filmoon.WebAPI.Services;

public class CustomersService
{
    public CustomersService(CustomersRepository customersRepository, UsersRepository usersRepository)
    {
        CustomersRepository = customersRepository;
        UsersRepository = usersRepository;
    }

    private CustomersRepository CustomersRepository { get; }
    private UsersRepository UsersRepository { get; }

    public async Task<ActionResponse> SignUpAsync(SignUpRequest userSignUpRequest)
    {
        if (UsersRepository.GetByUserNameAsync(userSignUpRequest.UserName) is not null) return new ActionResponse(false, $"User with name {userSignUpRequest.UserName} already exists.");

        var passwordSalt = PasswordGenerator.GenerateSalt();
        var passwordHash = PasswordGenerator.GenerateHash(userSignUpRequest.Password, passwordSalt);

        try
        {
            await CustomersRepository.AddAsync(new CustomerEntity() { UserName = userSignUpRequest.UserName, Email = userSignUpRequest.Email, PasswordSalt = passwordSalt, PasswordHash = passwordHash, RoleId = 2 });

            return new ActionResponse(true, $"Customer {userSignUpRequest.UserName} was added successful.");
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, $"Customer {userSignUpRequest.UserName} was not added successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }
}
