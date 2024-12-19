
using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    void SaveContactToFile(List<Contact> list);
    List<Contact> LoadListFromFile();

}
