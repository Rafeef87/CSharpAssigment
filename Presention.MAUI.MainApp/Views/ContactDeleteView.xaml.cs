using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class ContactDeleteView : ContentPage
{
	public ContactDeleteView(ContactDeletViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}