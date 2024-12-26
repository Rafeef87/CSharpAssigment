using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Pages;

public partial class ContactUpdatePage : ContentPage
{
	public ContactUpdatePage(ContactUpdateViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}