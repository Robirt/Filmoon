namespace Filmoon.Entities;

public class UserEntity : PersonEntity
{
    public string UserName { get; set; } = string.Empty;

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public virtual List<RentalEntity>? Rentals { get; set; }
}
