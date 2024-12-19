using System.Diagnostics;
using System.Text.Json.Serialization;
using Business.Converters;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

//Use Dependency Injection
public class ContactService : IContactService
{
    
    private readonly IFileService _fileService;
    //Create a list of Contacts
    private List<Contact> _contacts = new List<Contact>();
    public ContactService(IFileService fileService)
    {  
        _fileService = fileService;
        _contacts = _fileService.LoadListFromFile();
    }

    // Add a contact and save to file
    public bool AddContact(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);

            _contacts.Add(contact);
            // Convert the contact list to JSON and save it to the file
            _fileService.SaveContactToFile(_contacts);
            return true;
          
        }
        catch (Exception ex) 
        {
           Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
       
        var contacs = _fileService.LoadListFromFile();
        return contacs;
  
    }
  
}
