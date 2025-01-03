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
        _contactService.Update(ContactRegistrationForm);
        ContactRegistrationForm = new();
        await Shell.Current.GoToAsync("//ListView");
    }
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ContactRegistrationForm = (query["Contact"] as ContactRegistrationForm)!;
    }
}
