
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;

namespace Presention.MAUI.MainApp.ViewModels;

 public partial class ContactDeletViewModel(ContactService contactService) : ObservableObject
{
    private readonly ContactService _contactService = contactService;

    [ObservableProperty]
    private ContactRegistrationForm form;
    [ObservableProperty]
    private ObservableCollection<ContactPersone> contactList = new();


    [RelayCommand]
    private async Task DeleteContact()
    {
        if (Guid.TryParse(Form?.Id, out var contactId) && _contactService.GetContactById(contactId) != null)
        {
                // Remove the contact from the service
                _contactService.RemoveContactFromList(Form);
        }
            // Navigate back to the list after deletion
           await Shell.Current.GoToAsync("///ContactListView");
    }
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("///ContactListView");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is ContactRegistrationForm form)
        {
            Form = form;
        }
    }
}
