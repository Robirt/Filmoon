namespace Filmoon.Entities;

public class DirectorEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName { get => $"{FirstName} {LastName}"; }

    public DateTime BirthDate { get; set; }

    public virtual List<MovieEntity>? Movies { get; set; }

    public override string ToString() => FullName;
}
