using Business.Services;

var menuService = new MenuService();

while (true)
{
    menuService.ViewAllContactDialog();
    menuService.CreateContactDialog();
}