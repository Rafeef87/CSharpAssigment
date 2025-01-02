

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
                contactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts())
            };

        }

        [ObservableProperty]
        private ObservableCollection<ContactPersone> contactList = [];

        [RelayCommand]
        private async Task AddContactToList(ContactRegistrationForm form)
        {
            await Shell.Current.GoToAsync("AddView");
        }
        [RelayCommand]
        private async Task UpdateContactList(ContactRegistrationForm form)
        {
            var parameters = new ShellNavigationQueryParameters
            {
                {"Contact", form }
            };
            await Shell.Current.GoToAsync("AddView");
        }

        [RelayCommand]
        private void RemoveContactFromList(ContactRegistrationForm form)
        {
            _contactService.RemoveContactFromList(form);
            contactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts());
        }

    }
}