
using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class ContactEditView : ContentPage
{
	public ContactEditView(ContactUpdateViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}