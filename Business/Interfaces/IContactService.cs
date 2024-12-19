
using Business.Converters;
using Business.Models;

namespace Business.Interfaces;

public interface IContactService
{
    void Add(ContactRegistrationForm form);
    IEnumerable<Contact> GetAllContacts();
}
