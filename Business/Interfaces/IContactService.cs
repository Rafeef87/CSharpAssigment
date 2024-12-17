
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool Add(ContactRegistrationForm form);
    IEnumerable<Contact> GetAllContacts();
}
