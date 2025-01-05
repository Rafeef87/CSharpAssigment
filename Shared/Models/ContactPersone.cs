

namespace Shared.Models;

//Create a Contact class
public class ContactPersone
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public static implicit operator ContactPersone(ContactRegistrationForm newForm)
    {
        return new ContactPersone()
        {
            Id = newForm.Id,
            FirstName = newForm.FirstName,
            LastName = newForm.LastName,
            Email = newForm.Email,
            PhoneNumber = newForm.PhoneNumber,
            StreetAddress = newForm.StreetAddress,
            ZipCode = newForm.ZipCode,
            City = newForm.City,
        };
    }
}
