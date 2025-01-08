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
    public List<Contact> Contacts { get; private set; } = [];

    // Add a contact and save to file
    public bool AddContact(ContactRegistrationForm form)
    {
        try
        {
            var contact = ContactFactory.Create(form);
            if (contact != null && !string.IsNullOrWhiteSpace(contact.FirstName))
            {
                Contacts.Add(contact);
                _contactRepository.SaveToFile(Contacts);
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

    public List<Contact> GetAllContacts()
    {
        Contacts = _contactRepository.GetFormFile()!;
        return Contacts;
    }
  
    public bool RemoveContactFromList(ContactRegistrationForm form)
    {
        if (!string.IsNullOrWhiteSpace(form.FirstName))
        {
            var exisitingContact = Contacts.FirstOrDefault(x => x.FirstName == form.FirstName);
            if (exisitingContact != null)
            {
                Contacts.Remove(exisitingContact);
                return true;
            }
            return false;
        }
        return false;
    }
}
