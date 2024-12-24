using System.Text.Json;
using Business.Models;
using Business.Repositories;

namespace Business.Tests.Converters;

public class BaseRepository_Test
{
    private readonly ContactRepository _contactRepository;
    public BaseRepository_Test() 
    {
        _contactRepository = new ContactRepository();
    }

    [Fact]
    public void Serializ_ShouldConvertListToJson()
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

        var list = new List<Contact> { contact };

        //Act
        var result = _contactRepository.Serialize(list);
        //Assert
        Assert.NotNull(result);
    }
    [Fact]
    public void Deserialize_ConvertToList()
    {
        //Arrange
        var list = new List<Contact>();
        var json = JsonSerializer.Serialize(list);

        //Act
        var result = _contactRepository.Deserialize(json);
        //Assert
        Assert.NotNull(result);
        Assert.IsType<List<Contact>>(result);
    }
}
