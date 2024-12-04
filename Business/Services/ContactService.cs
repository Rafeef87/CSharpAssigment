using System.Collections.Generic;
using Business.Models;

namespace Business.Services;
//Create a list of Contacts
public class ContactService
{
    private List<Contact> _contacts = [];
    //Create a Contact
    public void CreateContact(Contact contact)
    {
        _contacts.Add(contact);
    }
    public IEnumerable<Contact> GetContacts()
    {
        return _contacts;
    }
}
