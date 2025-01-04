﻿

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
            // Update the list when there is a change in the contact list
            _contactService.ContactListaUpdate += (sender, e) =>
            {
                contactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts());
            };
            // Initializing the list
            contactList = new ObservableCollection<ContactPersone>(_contactService.GetAllContacts());
        }

        [ObservableProperty]
        private ObservableCollection<ContactPersone> contactList = new();
        // Navigate to "AddView"
        [RelayCommand]
        private async Task AddContactToList(ContactPersone contact)
        {
            contactList.Add(contact);

            await Shell.Current.GoToAsync("///ContactAddView");
        }
        // Navigate to "EditView" with form data
        [RelayCommand]
        private async Task UpdateContactList(ContactPersone contact)
        {
            contactList.Add(contact);

            await Shell.Current.GoToAsync("///ContactEditView");
        }
        // Remove contact from the list
        [RelayCommand]
        private async Task RemoveContactFromList(ContactPersone contact)
        {
            contactList.Remove(contact);

            await Shell.Current.GoToAsync("///ContactDeleteView");
        }

    }
}