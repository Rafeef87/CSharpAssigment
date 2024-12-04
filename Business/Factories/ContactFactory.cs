using Business.Models;
using Business.Services;

namespace Business.Factories;
//A menu item that creates a contact.
public class ContactFactory
{
    public static Contact Create(Contact form)
    {
        return new Contact()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            StreetAddress = form.StreetAddress,
            ZipCode = form.ZipCode,
            Locality = form.Locality,
        };
    }
}
