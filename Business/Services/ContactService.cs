using System.Diagnostics;
using Business.Converters;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;
//Create a list of Contacts
public class ContactService : IContactService
{
    
    private readonly IFileService _fileService;
    private List<Contact> _contacts = new List<Contact>();

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }
    // Add a contact and save to file
    public bool CreateContact(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);
            _contacts.Add(contact);
            // Convert the contact list to JSON and save it to the file
            var json = JsonContactConverter.ConvertToJson(_contacts);
            _fileService.SaveContactToFile(json);
            return true;
        }
        catch 
        {
            return false;
        }
    }
    public IEnumerable<Contact> GetContacts()
    {
        try
        {

            var json = _fileService.GetAllListFromFile();
             _contacts = JsonContactConverter.ConvertToList(json);
            return _contacts;
        }
        catch
        {
            return new List<Contact>();
        }
    }
    //Add a Contact
    public bool Add(ContactRegistrationForm form)
    {
        return CreateContact(form);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }
}
