using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class ContactListView : ContentPage
{
	public ContactListView(ContactListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}