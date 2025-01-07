
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    bool AddContact(ContactRegistrationForm form);
    List<Contact> GetAllContacts();
    //bool RemoveContactFromList(ContactRegistrationForm form);
}
