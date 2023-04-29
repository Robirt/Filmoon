namespace Filmoon.Entities;

public class ScreenwriterEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }

    public virtual List<MovieEntity>? Movies { get; set; }
}
