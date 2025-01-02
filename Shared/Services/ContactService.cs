
using Shared.Factories;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services;

public class ContactService(IFileService fileService) : IContactService
{
    public List<ContactPersone> Contacts { get; private set; } = [];
    private readonly IFileService _fileService = fileService;

    public bool AddContactToList(ContactRegistrationForm form)
    {
        var contact = ContactFactory.Create(form);
        if (form != null && !string.IsNullOrWhiteSpace(form.FirstName))
        {
            Contacts.Add(contact);
            _fileService.SaveContactToFile(Contacts);
            return true;
        }
        return false;
    }
      

    public IEnumerable<ContactPersone> GetAllContacts()
    {
        Contacts = _fileService.LoadListFromFile();
        return Contacts;
    }

    public bool RemoveContactFromList(ContactRegistrationForm form)
    {
        if (!string.IsNullOrWhiteSpace(form.FirstName))
        {
            var existingContact = Contacts.FirstOrDefault(x => x.FirstName == form.FirstName);
            if (existingContact != null)
            {
                Contacts.Remove(existingContact);
                _fileService.RemoveContactfromFile(Contacts);
                return true;
            }
        }

        return false;
    }
}
