

using Shared.Models;

namespace Shared.Factories
{
    public static class ContactFactory
    {
        public static ContactRegistrationForm Create()
        { 
              return new ContactRegistrationForm();
        }
        public static Contact Create(ContactRegistrationForm form)
        {
            return new Contact()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                StreetAddress = form.StreetAddress,
                ZipCode = form.ZipCode,
                City = form.City,
            };
        }
    }
}
