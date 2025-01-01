
using System.Collections.ObjectModel;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Business.Services;


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
    private ObservableCollection<Business.Models.Contact> _contactList = [];

    [RelayCommand]
    public void AddContactToList()
    {
        if (ContactRegistrationForm != null && !string.IsNullOrWhiteSpace(ContactRegistrationForm.FirstName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.LastName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.Email))
        {
            var result = _contactService.AddContact(ContactRegistrationForm);
            if (result)
            {
                UpdateContactList();
                ContactRegistrationForm = new ContactRegistrationForm();
            }
        
        }
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<Business.Models.Contact>(_contactService.Contacts.Select(contact => new Business.Models.Contact()).ToList());
    }

}
