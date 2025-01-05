
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
    public bool Update(ContactRegistrationForm newForm)
    {
        
        var contactInfo = Contacts.FirstOrDefault(x => x.Id == newForm.Id);

        if (newForm != null && !string.IsNullOrWhiteSpace(newForm.FirstName) &&
        !string.IsNullOrWhiteSpace(newForm.LastName) &&
        !string.IsNullOrWhiteSpace(newForm.Email) &&
        !string.IsNullOrWhiteSpace(newForm.PhoneNumber) &&
        !string.IsNullOrWhiteSpace(newForm.StreetAddress) &&
        !string.IsNullOrWhiteSpace(newForm.ZipCode) &&
        !string.IsNullOrWhiteSpace(newForm.City))
        {
            _fileService.SaveContactToFile(Contacts);

            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
            return true;
        }
        return false;
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
