namespace Filmoon.Entities;

public class RentalEntity
{
    public int Id { get; set; }

    public int? RentalId { get; set; }
    public virtual UserEntity? User { get; set; }

    public int? MovieId { get; set; }
    public virtual MovieEntity? Movie { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
