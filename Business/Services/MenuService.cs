using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;
//Build the main menu
public class MenuService(IContactService contactService)
{
    private  IContactService _contactService = contactService;

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
    public  void CreateContactDialog()
    {
        Console.Clear();
        //Add an item
        ContactRegistrationForm contactRegistrationForm = ContactFactory.Create() ;

        Console.Write("ENTER YOUR FIRST NAME: ");
        contactRegistrationForm.FirstName = Console.ReadLine()!;

        Console.Write("ENTER YOUR LAST NAME: ");
        contactRegistrationForm.LastName = Console.ReadLine()!;

        Console.Write("ENTER YOUR EMAIL: ");
        contactRegistrationForm.Email = Console.ReadLine()!;

        Console.Write("ENTER YOUR PHONE NUMBER: ");
        contactRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.Write("ENTER YOUR STREER ADDRESS: ");
        contactRegistrationForm.StreetAddress = Console.ReadLine()!;

        Console.Write("ENTER YOUR ZIP CODE: ");
        contactRegistrationForm.ZipCode = Console.ReadLine()!;

        Console.Write("ENTER YOUR LOCALITY: ");
        contactRegistrationForm.Locality = Console.ReadLine()!;

        bool result = _contactService.AddContact(contactRegistrationForm);
        if (result)
            OutPutDialog("USER WAS SUCCESSFULLY CREATED");
        else
            OutPutDialog("USER WAS NOT CREATED SUCCESSFULLY");
        
    }

    //View all items
    public  void ViewAllContactDialog()
    {
        Console.Clear();
        Console.WriteLine("-------- ALL CONTACTS -------");
        IEnumerable<Contact> contacts = _contactService.GetAllContacts();
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
    //Out Put message
    public void OutPutDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
