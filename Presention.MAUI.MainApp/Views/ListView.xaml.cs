using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class ListView : ContentPage
{
	public ListView(ContactListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}