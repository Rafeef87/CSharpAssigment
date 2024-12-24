using Business.Interfaces;
using Business.Models;
using Business.Repositories;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IContactFileService>(new ContactFileService("Data", "contacts.json"))
    .AddSingleton<IContactRepository, ContactRepository>()
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuService>()

.BuildServiceProvider();

var menuService = serviceProvider.GetRequiredService<MenuService>();
menuService.ShowMenu();
