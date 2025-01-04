
using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    bool AddContactToList(ContactRegistrationForm form);
    IEnumerable<ContactPersone> GetAllContacts();
    void Update(ContactRegistrationForm form);
    bool RemoveContactFromList(ContactRegistrationForm form);
}
