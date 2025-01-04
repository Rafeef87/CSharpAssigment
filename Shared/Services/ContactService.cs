
using Shared.Factories;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services;

public class ContactService(IFileService fileService) : IContactService
{
    public List<ContactPersone> Contacts = [];
    private ContactPersone contact;
    private readonly IFileService _fileService = fileService;

    public event EventHandler? ContactListaUpdate;
    public bool AddContactToList(ContactRegistrationForm form)
    {
        var contact = ContactFactory.Create(form);
        if (form != null && !string.IsNullOrWhiteSpace(form.FirstName) &&
            !string.IsNullOrWhiteSpace(form.LastName) &&
            !string.IsNullOrWhiteSpace(form.Email) &&
            !string.IsNullOrWhiteSpace(form.PhoneNumber) &&
            !string.IsNullOrWhiteSpace(form.StreetAddress) &&
            !string.IsNullOrWhiteSpace(form.ZipCode) &&
            !string.IsNullOrWhiteSpace(form.City))
        {
            Contacts.Add(contact);
            _fileService.SaveContactToFile(Contacts);
            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
            return true;
        }
        return false;
    }

    public IEnumerable<ContactPersone> GetAllContacts()
    {
        Contacts = _fileService.LoadListFromFile();
        return Contacts;
    }
    public void Update(ContactRegistrationForm form)
    {
        var contact = Contacts.FirstOrDefault(x => x.Id == form.Id);
        if (contact != null)
        {
            contact.FirstName = form.FirstName;
            contact.LastName = form.LastName;
            contact.Email = form.Email;
            contact.PhoneNumber = form.PhoneNumber;
            contact.StreetAddress = form.StreetAddress;
            contact.ZipCode = form.ZipCode;
            contact.City = form.City;

            _fileService.SaveContactToFile(Contacts);

            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool RemoveContactFromList(ContactRegistrationForm form)
    {
        
                    // Remove the contact from the list
                    Contacts.Remove(contact);
                    // Update the file
                    _fileService.RemoveContactfromFile(Contacts);
                    // Notify subscribers of update
                    ContactListaUpdate?.Invoke(this, EventArgs.Empty);
       
               return true;
    }
}
