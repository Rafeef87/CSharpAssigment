
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Services;
using Shared.Models;


namespace Presention.MAUI.MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ContactService _contactService;
    public MainViewModel(ContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();
    }

    [ObservableProperty]
    private ContactRegistrationForm _contactRegistrationForm = new();

    [ObservableProperty]
    private ObservableCollection<Shared.Models.Contact> _contactList = [];

    [RelayCommand]
    public bool AddContactToList()
    {
        if (ContactRegistrationForm != null && !string.IsNullOrWhiteSpace(ContactRegistrationForm.FirstName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.LastName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.Email))
                return true;
        {
            var result = _contactService.AddContactToList(ContactRegistrationForm);
            if (result)
            {
                UpdateContactList();
            }
        }
        return false;
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<Shared.Models.Contact>(_contactService.Contacts.Select(contact => new Shared.Models.Contact()).ToList());
    }

}
