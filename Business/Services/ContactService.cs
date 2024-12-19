using System.Diagnostics;
using System.Text.Json.Serialization;
using Business.Converters;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

//Use Dependency Injection
public class ContactService(IFileService fileService) : IContactService
{
    
    private readonly IFileService _fileService = fileService;
    //Create a list of Contacts
    private List<Contact> _contacts = new List<Contact>();


    // Add a contact and save to file
    public void Add(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);

            _contacts.Add(contact);
            // Convert the contact list to JSON and save it to the file
            JsonContactConverter.ConvertToJson(_contacts);
            // Convert the contact list to JSON and save it to the file
            _fileService.SaveContactToFile(_contacts);
          
        }
        catch (Exception ex) 
        {
           Debug.WriteLine(ex.Message);
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        try
        {
            _contacts = _fileService.LoadListFromFile();
            return _contacts;
        }
        catch
        {
            return new List<Contact>();
        }
    }
  
}
