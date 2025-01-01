using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp;

public partial class MainPage : ContentPage
{


    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}