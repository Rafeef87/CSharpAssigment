﻿
using Shared.Factories;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services;

public class ContactService(FileService fileService)
{
    private readonly FileService _fileService = fileService;
    public List<ContactPersone> contacts = [];

    
    public ContactPersone? GetContactById(Guid id)
    {
        return contacts.FirstOrDefault(x => Guid.TryParse(x.Id, out var parsedId) && parsedId == id);
    }
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
            contacts.Add(contact);
            _fileService.SaveContactToFile(contacts);
            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
            return true;
        }
        return false;
    }
    public IEnumerable<ContactPersone> GetAllContacts()
    {
        contacts = _fileService.LoadListFromFile();
        return contacts;
    }
    public bool Update(ContactRegistrationForm form)
    {
        
        var existingContact = contacts.FirstOrDefault(x => x.Id == form.Id);

        if (existingContact != null)
        {
            existingContact.FirstName = form.FirstName;
            existingContact.LastName = form.LastName;
            existingContact.Email = form.Email;
            existingContact.PhoneNumber = form.PhoneNumber;
            existingContact.StreetAddress = form.StreetAddress;
            existingContact.ZipCode = form.ZipCode;
            existingContact.City = form.City;

            _fileService.SaveContactToFile(contacts);
            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
            return true;
        }
        return false;
    }
    public bool RemoveContactFromList(ContactRegistrationForm form)
    {
        if (form == null)
        {
            return false;
        }
        var contactToRemove = contacts.FirstOrDefault(x => x.Id == form.Id);

        if (contactToRemove != null)
        {
            // Remove the contact from the list
            contacts.Remove(contactToRemove);

            // Update the file
            _fileService.SaveContactToFile(contacts);
            // Notify subscribers of update
            ContactListaUpdate?.Invoke(this, EventArgs.Empty);
       
            return true;
        }
        return false;
    }
}
