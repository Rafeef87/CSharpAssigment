using Shared.Models;

namespace Shared.Interfaces
{
    public interface IFileReader
    {
        List<ContactPersone> LoadListFromFile();
    }
}