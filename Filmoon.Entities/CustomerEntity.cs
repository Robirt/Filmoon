namespace Filmoon.Entities;

public class CustomerEntity : UserEntity
{
    public virtual List<RentalEntity>? Rentals { get; set; }
}
