using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Business.Interfaces;
using Business.Models;

namespace Business.Repositories;

public class ContactRepository(IContactFileService contactFileService) : BaseRepository<Contact>, IContactRepository
{
    private readonly IContactFileService _contactFileService = contactFileService;

    // Get JSON from file and deserialize to a list
    public override List<Contact>? GetFormFile()
    {
        try
        { 
            var json = _contactFileService.LoadListFromFile();
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
