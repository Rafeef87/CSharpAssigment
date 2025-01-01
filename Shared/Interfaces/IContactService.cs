
using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(ContactRegistrationForm form);
    IEnumerable<Contact> GetAllContacts();
    bool RemoveContactFromList(ContactRegistrationForm form);
}
