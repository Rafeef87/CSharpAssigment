using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder().ConfigureServices((config, services) =>
{
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IFileService, FileService>();
    services.AddSingleton<MenuService>();
})
.Build();

var menuService = host.Services.GetRequiredService<MenuService>();
menuService?.ShowMenu();
