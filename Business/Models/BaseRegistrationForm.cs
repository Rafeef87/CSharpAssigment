
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public abstract class BaseRegistrationForm
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Locality { get; set; } = null!;
    public abstract bool IsRegistered();
}
