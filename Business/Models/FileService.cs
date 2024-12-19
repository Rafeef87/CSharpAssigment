using Business.Converters;
using Business.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Models;
//Create a file service
public class FileService : IFileService
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

    public void SaveContactToFile(List<Contact> list)
    {

        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
        var json = JsonContactConverter.ConvertToJson(list);
        File.WriteAllText(_filePath, json);
    }

    public List<Contact> LoadListFromFile()
    {
            var json = File.ReadAllText(_filePath);
            var contacts = JsonContactConverter.ConvertToList(json);
            return contacts;

    }
}
