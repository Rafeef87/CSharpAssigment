using System.Diagnostics;
using System.Text.Json;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath;
        private readonly string _directoryPath;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public FileService(string directoryPath = "Data", string fileName = "list.json")
        {
            _directoryPath = directoryPath;
            _filePath = Path.Combine(_directoryPath, fileName);
            _jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        }
        public void SaveContactToFile(List<ContactPersone> list)
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                    Directory.CreateDirectory(_directoryPath);

                var json = JsonSerializer.Serialize(list, _jsonSerializerOptions);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public List<ContactPersone> LoadListFromFile()
        {
            try
            {
                if (!File.Exists(_filePath))
                    return [];
                var json = File.ReadAllText(_filePath);
                var list = JsonSerializer.Deserialize<List<ContactPersone>>(json, _jsonSerializerOptions);
                return list ?? [];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return [];
            }
        }

        public bool RemoveContactfromFile(List<ContactPersone> list)
        {
            try
            {
                // If the list is empty or null, return false
                if (list != null || !list.Any())
                    return true;
                // Save the updated list back to the file
                SaveContactToFile(list);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        
    }
}