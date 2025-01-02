using Presention.MAUI.MainApp.Views;

namespace Presention.MAUI.MainApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListView), typeof(ListView));
            Routing.RegisterRoute(nameof(AddView), typeof(AddView));
            Routing.RegisterRoute(nameof(EditView), typeof(EditView));

        }
    }
}
