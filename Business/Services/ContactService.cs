using System.Collections.Generic;
using Business.Models;

namespace Business.Services;
//Create a list of Contacts
public class ContactService
{
    private List<Contact> _contacts = [];
    private readonly FileService _fileService = new();
    //Add a Contact
    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }
    public List<Contact> GetAllContacts()
    {
        return _contacts;
    }
}
