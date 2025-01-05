
using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(ContactRegistrationForm form);
    IEnumerable<ContactPersone> GetAllContacts();
    bool Update(ContactRegistrationForm newForm);
    bool RemoveContactFromList(ContactRegistrationForm form);
}
