
namespace Business.Interfaces;

public interface IFileService
{
    bool SaveContactToFile(string contact);
    string GetAllListFromFile();

}
