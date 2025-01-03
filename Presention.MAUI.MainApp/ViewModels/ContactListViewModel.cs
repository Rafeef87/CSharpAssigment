

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presention.MAUI.MainApp.Views;
using Shared.Models;
using Shared.Services;

namespace Presention.MAUI.MainApp.ViewModels
{ 
    public partial class ContactListViewModel : ObservableObject
    {
        private readonly ContactService _contactService;
        public ContactListViewModel(ContactService contactService)
        {
            _contactService = contactService;
            _contactService.ContactListaUpdate += (sender, e) =>
            {
                contactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts());
            };
        }

        [ObservableProperty]
        private ObservableCollection<ContactPersone> contactList = [];
        // Navigate to "AddView"
        [RelayCommand]
        private async Task AddContactToList()
        {
            await Shell.Current.GoToAsync("ContactAddView");
        }
        // Navigate to "EditView" with form data
        [RelayCommand]
        private async Task UpdateContactList(ContactPersone contact)
        {
            var parameters = new ShellNavigationQueryParameters
            {
                {"Contact", contact }
            };
            await Shell.Current.GoToAsync(nameof(ContactEditView), parameters);
        }
        // Remove contact from the list
        [RelayCommand]
        private void RemoveContactFromList(ContactPersone contact)
        {
            _contactService.RemoveContactFromList(new ContactRegistrationForm
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                StreetAddress = contact.StreetAddress,
                ZipCode = contact.ZipCode,
                City = contact.City
            });
            ContactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts());
        }

    }
}