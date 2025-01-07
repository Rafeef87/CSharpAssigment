using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace Business.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{
    private readonly IContactFileService _contactFileService;

    public ContactRepository(IContactFileService contactFileService)
    {
        _contactFileService = contactFileService;

    }

    // Get JSON from file and deserialize to a list
    public override List<Contact>? GetFormFile()
    {
        try
        {
            string json = _contactFileService.LoadListFromFile();
            var list = Deserialize(json);
            return list;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
    // Save list as JSON string to file
    public override bool SaveToFile(List<Contact> list)
    {
        try
        {
            var json = JsonSerializer.Serialize(list);
            _contactFileService.SaveContactToFile(json);
            return true;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
