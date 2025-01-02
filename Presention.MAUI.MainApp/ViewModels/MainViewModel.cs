
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
    private ContactRegistrationForm contactRegistrationForm = new();

    [ObservableProperty]
    private ObservableCollection<ContactPersone> contactList = [];

    [RelayCommand]
    public void AddContactToList()
    {
        if (ContactRegistrationForm != null &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.FirstName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.LastName) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.Email) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.PhoneNumber) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.StreetAddress) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.ZipCode) &&
                !string.IsNullOrWhiteSpace(ContactRegistrationForm.City))
        {
            var result = _contactService.AddContactToList(ContactRegistrationForm);
            if (result)
            {
                UpdateContactList();
                ContactRegistrationForm = new();
            }
        }
    }
    [RelayCommand]
    public void RemoveContactFromList(ContactRegistrationForm form)
    {
        if(form != null)
        {
            var result = _contactService.RemoveContactFromList(form);
            if (result)
            { 
                UpdateContactList();
            }
        }
    }

    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<ContactPersone>(_contactService.Contacts
            .Select(contact => contact).ToList());
    }
}
