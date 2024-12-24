
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactFileService : FileService, IContactFileService
{
    public ContactFileService(string directoryPath, string fileName) : base(directoryPath, fileName)
    { 

    }

    public override string LoadListFromFile()
    {
        return base.LoadListFromFile();
    }

    public override bool SaveContactToFile(string list)
    {
        return base.SaveContactToFile(list);
    }
}
