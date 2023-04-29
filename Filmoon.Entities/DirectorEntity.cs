namespace Filmoon.Entities;

public class DirectorEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }

    public List<MovieEntity>? Movies { get; set; }
}
