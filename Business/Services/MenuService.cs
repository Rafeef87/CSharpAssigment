using Business.Models;

namespace Business.Services;
//Build the main menu
public class MenuService
{
    private readonly ContactService _contacts = new();
    public void CreateContactDialog()
    {
        Console.Clear();
        //Add an item
        var contact = new Contact();

        Console.Write("ENTER YOUR FIRST NAME: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("ENTER YOUR LAST NAME: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("ENTER YOUR EMAIL: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("ENTER YOUR PHONE NUMBER: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("ENTER YOUR STREER ADDRESS: ");
        contact.StreetAddress = Console.ReadLine()!;

        Console.Write("ENTER YOUR ZIP CODE: ");
        contact.ZipCode = Console.ReadLine()!;

        Console.Write("ENTER YOUR LOCALITY: ");
        contact.Locality = Console.ReadLine()!;

        _contacts.Add(contact);
    }

    //View all items
    public void ViewAllContactDialog()
    {
        Console.Clear();
        var contacts = _contacts.GetAllContacts();
        foreach (var contact in contacts)
        {
            Console.WriteLine($"[{contact.Id},{contact.FirstName},{contact.LastName},{contact.Email},{contact.PhoneNumber},{ contact.StreetAddress},{contact.ZipCode},{ contact.Locality}]");
        }
        Console.ReadKey();
    }
}
