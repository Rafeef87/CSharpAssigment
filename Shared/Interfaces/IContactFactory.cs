
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IContactFactory
    {
        ContactPersone Create(ContactPersone contact);
    }
}
