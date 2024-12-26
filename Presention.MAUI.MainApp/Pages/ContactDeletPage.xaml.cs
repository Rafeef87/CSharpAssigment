using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Pages;

public partial class ContactDeletPage : ContentPage
{
	public ContactDeletPage(ContactDeletViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}