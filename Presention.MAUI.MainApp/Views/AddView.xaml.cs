using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class AddView : ContentPage
{
	public AddView(ContactAddViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}