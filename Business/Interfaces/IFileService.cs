
using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    bool SaveContactToFile(List<Contact> list);
    List<Contact> LoadListFromFile();

}
