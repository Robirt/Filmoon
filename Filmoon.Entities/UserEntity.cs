namespace Filmoon.Entities;

public class UserEntity
{
    public string UserName { get; set; } = string.Empty;

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string Email { get; set; } = string.Empty;

    public int? RoleId { get; set; }
    public virtual RoleEntity? Role { get; set; }
}
