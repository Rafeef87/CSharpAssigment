using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;



namespace Presention.MAUI.MainApp.ViewModels;

public partial class ContactUpdateViewModel(ContactService contactService) : ObservableObject
{
    private readonly ContactService _contactService = contactService;
    [ObservableProperty]
    private ContactRegistrationForm newForm = new();
    [RelayCommand]
    private async Task EditContact()
    {
        // Update the contact in the service
        _contactService.Update(newForm);
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
