
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
        _contactService.AddContactToList(ContactRegistrationForm);
        ContactRegistrationForm = new();

        await Shell.Current.GoToAsync("..");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Contact", out var contact) && contact is ContactRegistrationForm form)
        {
            ContactRegistrationForm = form!;
        }
    }
}
