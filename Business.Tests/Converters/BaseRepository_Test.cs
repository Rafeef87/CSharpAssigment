using System.Text.Json;
using Business.Interfaces;
using Business.Models;
using Business.Repositories;
using Moq;

namespace Business.Tests.Converters;

public class BaseRepository_Test
{
    private readonly ContactRepository _contactRepository;

    public BaseRepository_Test()
    {
        // Mocka IContactFileService
        var mockContactFileService = new Mock<IContactFileService>();

        // Mock för fil-läsning och skrivning
        mockContactFileService
            .Setup(service => service.LoadListFromFile())
            .Returns("[]"); // Returnera en tom lista som JSON

        mockContactFileService
            .Setup(service => service.SaveContactToFile(It.IsAny<string>()));

        // Skapa ContactRepository med mockad tjänst
        _contactRepository = new ContactRepository(mockContactFileService.Object);
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
        string result = _contactRepository.Serialize(list);
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
