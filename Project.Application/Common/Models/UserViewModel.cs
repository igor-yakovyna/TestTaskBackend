namespace Project.Application.Common.Models;

public class UserViewModel
{
    public Guid UserId { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public string Street { get; set; }

    public string HouseNumber { get; set; }

    public string ApartmentNumber { get; set; }

    public string Town { get; set; }

    public string PostalCode { get; set; }
}