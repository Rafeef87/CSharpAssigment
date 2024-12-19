
using System.Text.Json;
using Business.Converters;
using Business.Models;

namespace Business.Tests.Converters;

public class JsonContactConverter_Test
{
    [Fact]
    public void ConvertToJson_ShouldConvertListToJson()
    {
        //Arrange
        var contact = new Contact()
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        var list = new List<Contact>();

        //Act
        var result = JsonContactConverter.ConvertToJson(list);
        //Assert
        Assert.NotNull(result);
    }
    [Fact]
    public void ConvertToList()
    {
        //Arrange
        var contact = new Contact()
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        var list = new List<Contact>();
        var json = JsonSerializer.Serialize(list);

        //Act
        var result = JsonContactConverter.ConvertToList(json);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Contact>>(result);
    }
}
