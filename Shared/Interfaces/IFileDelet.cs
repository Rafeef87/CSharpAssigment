using Shared.Models;

namespace Shared.Interfaces
{
    public interface IFileDelet
    {
        bool RemoveContactfromFile(List<Contact> list);
    }
}