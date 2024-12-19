using Business.Interfaces;
using Business.Models;
using Business.Services;

IFileService fileService = new FileService();
var contactService = new ContactService(fileService);
var menuService = new MenuService(contactService);
menuService.ShowMenu();
