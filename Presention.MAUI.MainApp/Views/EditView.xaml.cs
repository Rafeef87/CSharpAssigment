
using Presention.MAUI.MainApp.ViewModels;

namespace Presention.MAUI.MainApp.Views;

public partial class EditView : ContentPage
{
	public EditView(ContactUpdateViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}