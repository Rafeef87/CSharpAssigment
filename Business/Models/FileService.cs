using Business.Converters;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Business.Models;
//Create a file service
public class FileService
{
    private readonly string _filePath;
    private readonly string _directoryPath;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public FileService(string directoryPath= "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
       
        _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true};
    }
    public void SaveListToFlie(List<Contact> list)
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
        try
        {
            if (!File.Exists(_filePath))
                return [];

            var json = File.ReadAllText(_filePath);
            var list = JsonContactConverter.ConvertToList(json);
            return list;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}
