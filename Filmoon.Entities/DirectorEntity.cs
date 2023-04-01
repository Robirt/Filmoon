namespace Filmoon.Entities;

public class DirectorEntity : PersonEntity
{
    public List<MovieEntity>? Movies { get; set; }
}
