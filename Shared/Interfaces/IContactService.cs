
using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(ContactRegistrationForm form);
    IEnumerable<ContactPersone> GetAllContacts();
    bool RemoveContactFromList(ContactRegistrationForm form);
}
