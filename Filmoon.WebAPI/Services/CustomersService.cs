using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Repositories;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Filmoon.WebAPI.Services;

public class CustomersService
{
    public CustomersService(CustomersRepository customersRepository)
    {
        CustomersRepository = customersRepository;
    }

    private CustomersRepository CustomersRepository { get; }

    public async Task<UserSignUpResponse> SignUpAsync(UserSignInRequest userSignInRequest)
    {
        if (CustomersRepository.GetByUserNameAsync(userSignInRequest.UserName) is not null) return new UserSignUpResponse(false, "User with that name already exists.");

        var passwordSalt = GenerateSalt();
        var passwordHash = GenerateHash(userSignInRequest.Password, passwordSalt);

        var customer = new CustomerEntity() { UserName = userSignInRequest.UserName, Email = userSignInRequest.Email, PasswordSalt = passwordSalt, PasswordHash = passwordHash };

        try
        {
            await CustomersRepository.AddAsync(customer);

            return new UserSignUpResponse(true, $"Customer {userSignInRequest.UserName} was added successful.");
        }

        catch (Exception exception)
        {
            return new UserSignUpResponse(false, $"Customer {userSignInRequest.UserName} was not added successful. An exception occured: {exception.Message ?? exception.InnerException?.Message ?? "Undefined message"}.");
        }
    }

    private byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private string GenerateHash(string password, byte[] salt)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] combinedBytes = new byte[salt.Length + passwordBytes.Length];
        Array.Copy(salt, 0, combinedBytes, 0, salt.Length);
        Array.Copy(passwordBytes, 0, combinedBytes, salt.Length, passwordBytes.Length);

        byte[] hashBytes = new SHA256Managed().ComputeHash(combinedBytes);
        return Convert.ToBase64String(hashBytes);
    }
}
