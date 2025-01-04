
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;


namespace Presention.MAUI.MainApp.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly ContactService _contactService;
    public ContactAddViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }
    [ObservableProperty]
    private ContactRegistrationForm contactRegistrationForm = new();

    [RelayCommand]
    private async Task Add()
    {
        // Add the contact to service
        _contactService.AddContactToList(ContactRegistrationForm);
        // Reset the contact form after saving
        ContactRegistrationForm = new();
        // Navigate back to ListView
        await Shell.Current.GoToAsync("///ContactListView");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is ContactRegistrationForm form)
        {
            ContactRegistrationForm = form;
        }
    }
}
