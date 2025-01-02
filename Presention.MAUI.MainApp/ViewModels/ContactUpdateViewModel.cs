using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;

namespace Presention.MAUI.MainApp.ViewModels;

public partial class ContactUpdateViewModel : ObservableObject
{
    [ObservableProperty]
    private ContactRegistrationForm contactRegistrationForm = new();

    [RelayCommand]
    private void Update()
    {

    }
}
