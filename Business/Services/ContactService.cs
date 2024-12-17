using System.Diagnostics;
using Business.Factories;
using Business.Models;

namespace Business.Services;
//Create a list of Contacts
public class ContactService
{
    private readonly List<Contact> _contacts = [];
    private readonly FileService _fileService = new();
    //Add a Contact
    public void Add(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);
            _contacts.Add(contact);
            _fileService.SaveListToFlie(_contacts);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
    public List<Contact> GetAllContacts()
    {
        var contacts = _fileService.LoadListFromFile();
        return contacts;
    }
}
