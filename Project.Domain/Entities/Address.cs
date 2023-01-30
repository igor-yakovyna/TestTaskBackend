namespace Project.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }

    public string Street { get; set; }

    public string HouseNumber { get; set; }

    public string ApartmentNumber { get; set; }

    public string Town { get; set; }

    public string PostalCode { get; set; }

    #region Navigation properties

    public virtual Guid UserId { get; set; }

    public virtual User User { get; set; }

    #endregion
}