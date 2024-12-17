using Business.Models;

namespace Business.Factories;
//A menu item that creates a contact.
public static class ContactFactory
{
    public static ContactRegistrationForm Create() => new ();
    public static Contact Create(ContactRegistrationForm form) => new Contact
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email,
        PhoneNumber = form.PhoneNumber,
        StreetAddress = form.StreetAddress,
        ZipCode = form.ZipCode,
        Locality = form.Locality,
    };
}
