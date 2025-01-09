
using Presention.MAUI.MainApp.ViewModels;
using Presention.MAUI.MainApp.Views;
using Shared.Interfaces;
using Shared.Services;


namespace Presention.MAUI.MainApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ContactService>();
            builder.Services.AddSingleton<FileService>();
            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactListView>();
            builder.Services.AddSingleton<ContactAddViewModel>();
            builder.Services.AddSingleton<ContactAddView>();
            builder.Services.AddSingleton<ContactUpdateViewModel>();
            builder.Services.AddSingleton<ContactEditView>();
            builder.Services.AddSingleton<ContactDeletViewModel>();
            builder.Services.AddSingleton<ContactDeleteView>();


            return builder.Build();
        }
    }
}
