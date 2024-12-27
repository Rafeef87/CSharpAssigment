
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services;

public class ContactService(IFileService fileService) : IContactService
{
    private List<Contact> _contacts = [];
    private readonly IFileService _fileService = fileService;

    public void AddContactToList(Contact contact)
    {
        _contacts.Add(contact);
        _fileService.SaveContactToFile(_contacts);
    }
    public IEnumerable<Contact> GetAllContacts()
    {
        _contacts = _fileService.LoadListFromFile();
        return _contacts;
    }

    public bool RemoveContactFromList(Contact contact)
    {
        _contacts.Remove(contact);
        _fileService.RemoveContactfromFile(_contacts);
        return true;
    }
}
