using System.Diagnostics;
using System.Text.Json.Serialization;
using Business.Factories;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Repositories;

namespace Business.Services;

//Use Dependency Injection
public class ContactService(IContactRepository contactRepository) : IContactService
{
    
    private readonly IContactRepository _contactRepository = contactRepository;
    //Create a list of Contacts
    private List<Contact> _contacts = [];

    // Add a contact and save to file
    public bool AddContact(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);
            if (contact != null)
            {
                _contacts.Add(contact);
                // Convert the contact list to JSON and save it to the file
                _contactRepository.SaveToFile(_contacts);
                return true;
            }
            return false;
        }
        catch (Exception ex) 
        {
           Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _contactRepository.GetFormFile()!;
        return _contacts;
    }
}
