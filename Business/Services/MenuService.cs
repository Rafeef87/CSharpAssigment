using Business.Models;

namespace Business.Services;
//Build the main menu
public class MenuService
{
    private readonly ContactService _contacts = new();

    //Show Menu

    public void ShowMenu()
    {
        var isRunning = true;
        do
        {
            Console.Clear();
            Console.WriteLine("-------- CONTACT LIST -------");
            Console.WriteLine("1. ADD NEW CONTACT");
            Console.WriteLine("2. VIEW ALL CONTACT");
            Console.WriteLine("q EXIT APPLICATION");
            Console.WriteLine("-----------------------------");
            Console.Write("ENTER OPTION: ");

            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    CreateContactDialog();
                    break;
                    case "2":
                    ViewAllContactDialog();
                    break;
                    case "q":
                    Console.Clear();
                    Console.WriteLine("PRESS ANY KEY TO EXIT.");
                    Console.ReadKey();
                    isRunning = false;
                    break;
                    default:
                    Console.WriteLine("INVALID OPTION. PLEASE TRY AGAIN.");
                    Console.ReadKey();
                    break;
            }

        } while (isRunning);      
    }
    public void CreateContactDialog()
    {
        Console.Clear();
        //Add an item
        var contact = new ContactRegistrationForm();

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
        Console.WriteLine("-------- ALL CONTACTS -------");
        var contacts = _contacts.GetAllContacts();
        if (!contacts.Any())
        {
            Console.WriteLine("NO CONTACT FOUND. PRESS ANY KEY TO GO BACK");
            Console.ReadKey();
            return;
        }
        foreach (var contact in contacts)
        {
            Console.WriteLine($"[{contact.Id},{contact.FirstName},{contact.LastName},{contact.Email},{contact.PhoneNumber},{ contact.StreetAddress},{contact.ZipCode},{ contact.Locality}]");
        }
        Console.ReadKey();
    }
}
