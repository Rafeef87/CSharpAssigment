
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ContactRegistrationForm : BaseRegistrationForm
{
    public string PhoneNumber { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;

    public override bool IsRegistered()
    {
        return false;
    }
}
