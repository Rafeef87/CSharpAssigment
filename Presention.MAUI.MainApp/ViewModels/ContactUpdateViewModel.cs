using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;

namespace Presention.MAUI.MainApp.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public ContactUpdateViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }
    [ObservableProperty]
    private ContactRegistrationForm contactRegistrationForm = new();

    [RelayCommand]
    private async Task Update()
    {
        // Update the contact in the service
        _contactService.Update(ContactRegistrationForm);
        // Navigate back to the list of contacts
        await Shell.Current.GoToAsync("///ContactListView");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is ContactPersone persone)
        {
            ContactRegistrationForm = new ContactRegistrationForm
            {
                Id = persone.Id,
                FirstName = persone.FirstName,
                LastName = persone.LastName,
                Email = persone.Email,
                PhoneNumber = persone.PhoneNumber,
                StreetAddress = persone.StreetAddress,
                ZipCode = persone.ZipCode,
                City = persone.City
            };
        }
    }
}
