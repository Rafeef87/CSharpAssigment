using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;



namespace Presention.MAUI.MainApp.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    private readonly ContactService _contactService;
    [ObservableProperty]
    private ContactRegistrationForm newForm = new();

    public ContactUpdateViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    private async Task EditContact()
    {
        if (Guid.TryParse(NewForm.Id, out var contactId))
        {
            // Check if contact exists and update
            var existingContact = _contactService.GetContactById(contactId);
            if (existingContact != null)
            {
                // Update the existing contact in the service
                _contactService.Update(NewForm);
            }
            else
            {
                // Add new contact if it doesn't exist
                _contactService.AddContactToList(NewForm);
            }
        }
       
            // Reset the form
            NewForm = new ();
        // Navigate back to the list of contacts
        await Shell.Current.GoToAsync("///ContactListView");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is ContactRegistrationForm newForm)
        {
            NewForm = newForm;
        }

    }
}
