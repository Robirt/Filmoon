namespace Filmoon.Entities;

public class RentalEntity
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }
    public virtual CustomerEntity? Customer { get; set; }

    public int? MovieId { get; set; }
    public virtual MovieEntity? Movie { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
