namespace Filmoon.Entities;

public class MovieEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateOnly ReleaseDate { get; set; }

    public byte[]? Poster { get; set; }

    public int LengthInMinutes { get; set; }

    public double LengthInHours { get => LengthInMinutes / 60; }

    public virtual List<GenreEntity>? Genres { get; set; }

    public virtual List<DirectorEntity>? Directors { get; set; }

    public virtual List<ScreenwriterEntity>? Screenwriters { get; set; }

    public double Price { get; set; }
}
