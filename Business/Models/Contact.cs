namespace Business.Models;
//Create a Contact class
public class Contact
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Locality { get; set; } = null!;
    public bool IsRegistered { get; set; }
}
