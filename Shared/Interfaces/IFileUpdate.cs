
using Shared.Models;

namespace Shared.Interfaces;

public interface IFileUpdate
{
    bool UpdateContactInFile(List<ContactPersone> list);
}
