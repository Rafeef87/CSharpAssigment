using Business.Services;

var menuService = new MenuService();
menuService.ShowMenu();


while (true)
{
    menuService.ViewAllContactDialog();
    menuService.CreateContactDialog();
}