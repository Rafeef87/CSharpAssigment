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
        _fileService.SaveListToFlie(_contacts);
    }
    public List<Contact> GetAllContacts()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }
}
