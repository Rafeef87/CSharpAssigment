using Microsoft.Extensions.Logging;
using Presention.MAUI.MainApp.Pages;
using Presention.MAUI.MainApp.ViewModels;

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

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ContactListPage>();
            builder.Services.AddSingleton<ContactAddPage>();
            builder.Services.AddSingleton<ContactUpdatePage>();
            builder.Services.AddSingleton<ContactDeletPage>();
            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactAddViewModel>();
            builder.Services.AddSingleton<ContactUpdateViewModel>();
            builder.Services.AddSingleton<ContactDeletViewModel>();

            return builder.Build();
        }
    }
}
