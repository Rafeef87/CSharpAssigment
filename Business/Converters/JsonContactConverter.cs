using System.Text.Json.Serialization;
using System.Text.Json;
using Business.Models;

namespace Business.Converters;

public static class JsonContactConverter
{
    public static string ConvertToJson(List<Contact> list)
    {
        var json = JsonSerializer.Serialize(list);
        return json;
    }
    public static List<Contact> ConvertToList(string json)
    {
        var list = JsonSerializer.Deserialize<List<Contact>>(json);
        return list ?? [];
    }
}
