using Presention.MAUI.MainApp.Pages;

namespace Presention.MAUI.MainApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactListPage), typeof(ContactListPage));
            Routing.RegisterRoute(nameof(ContactAddPage), typeof(ContactAddPage));
            Routing.RegisterRoute(nameof(ContactUpdatePage), typeof(ContactUpdatePage));
            Routing.RegisterRoute(nameof(ContactDeletPage), typeof(ContactDeletPage));
        }
    }
}
