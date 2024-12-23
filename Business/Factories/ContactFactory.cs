using System.Diagnostics;
using Business.Models;

namespace Business.Factories;
//A menu item that creates a contact.
public static class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }
    public static Contact Create(BaseRegistrationForm registrationForm)
    {
        try
        {
            if (registrationForm is ContactRegistrationForm form)
            { 
                return new Contact
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    PhoneNumber = form.PhoneNumber,
                    StreetAddress = form.StreetAddress,
                    ZipCode = form.ZipCode,
                    Locality = form.Locality,
                    IsRegistered = form.IsRegistered()
                };
            }
            return null!; 
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"ERROR CREATING CONTACT {ex.Message}");
            return null!;
        }
    }
}
