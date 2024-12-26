using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Pages;

public partial class ContactAddPage : ContentPage
{
	public ContactAddPage(ContactAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}