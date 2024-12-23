
using Business.Interfaces;
using Business.Repositories;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Models;
//Create a file service
public abstract class FileService : IFileService
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath= "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
        _jsonSerializerOptions = new JsonSerializerOptions();
        
    }

    public virtual bool SaveContactToFile(string list)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            { 
                Directory.CreateDirectory(_directoryPath);
            }
            File.WriteAllText(_filePath, list);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public virtual string LoadListFromFile()
    {
            if (!File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
        return null!;
    }
}
