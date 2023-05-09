namespace Filmoon.Entities;

public class MovieEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public byte[]? Poster { get; set; }

    public int LengthInMinutes { get; set; }

    public double LengthInHours { get => LengthInMinutes / 60; }

    public int? GenreId { get; set; }
    public virtual GenreEntity? Genre { get; set; }

    public int? DirectorId { get; set; }
    public virtual DirectorEntity? Director { get; set; }

    public int? ScreenwriterId { get; set; }
    public virtual ScreenwriterEntity? Screenwriter { get; set; }

    public double Price { get; set; }

    public override string ToString() => Title;
}
