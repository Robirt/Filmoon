namespace Filmoon.Entities;

public class GenreEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public override string ToString() => Name;
}
