
using Shared.Models;

namespace Shared.Interfaces;

public interface IContactService
{
    void AddContactToList(Contact contact);
    IEnumerable<Contact> GetAllContacts();
    bool RemoveContactFromList(Contact contact);
}
