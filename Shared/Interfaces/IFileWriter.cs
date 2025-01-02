using Shared.Models;

namespace Shared.Interfaces
{
    public interface IFileWriter
    {
        void SaveContactToFile(List<ContactPersone> list);
    }
}