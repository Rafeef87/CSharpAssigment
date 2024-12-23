
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool AddContact(ContactRegistrationForm form);
    IEnumerable<Contact> GetAllContacts();
}
