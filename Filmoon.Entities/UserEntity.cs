namespace Filmoon.Entities;

public class UserEntity
{
    public int Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public byte[] PasswordSalt { get; set; } = new byte[16];

    public string Email { get; set; } = string.Empty;

    public int? RoleId { get; set; }
    public virtual RoleEntity? Role { get; set; }
}
