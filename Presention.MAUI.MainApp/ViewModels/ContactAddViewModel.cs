
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

    [RelayCommand]
    private void Add()
    {
     

    }
}
