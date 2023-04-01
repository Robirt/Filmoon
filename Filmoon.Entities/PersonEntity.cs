namespace Filmoon.Entities;

public abstract class PersonEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }
}
