using Presention.MAUI.MainApp.Views;


namespace Presention.MAUI.MainApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ContactListView), typeof(ContactListView));
            Routing.RegisterRoute(nameof(ContactAddView), typeof(ContactAddView));
            Routing.RegisterRoute(nameof(ContactEditView), typeof(ContactEditView));
            Routing.RegisterRoute(nameof(ContactDeleteView), typeof(ContactDeleteView));

        }
    }
}
