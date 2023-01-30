using Project.Domain.Common;

namespace Project.Domain.Entities;

public class User : Entity<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string PhoneNumber { get; set; }

    public Address Address { get; set; }
}