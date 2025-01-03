﻿
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presention.MAUI.MainApp.ViewModels;

 public partial class ContactDeletViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("ContactListPage");
    }
}
