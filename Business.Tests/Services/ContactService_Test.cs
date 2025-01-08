using Business.Interfaces;
using Business.Models;
using Business.Repositories;
using Business.Services;
using Moq;

namespace Business.Tests;

public class ContactService_Test
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly IContactService _contactService;
    public ContactService_Test()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _contactService = new ContactService(_contactRepositoryMock.Object);
    }
    [Fact]
    public void CreateContact_ShouldAddContactToList_AndSaveToFile()
    {
        // Arrange
        var form = new ContactRegistrationForm
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        var contacts = new List<Contact>();

        _contactRepositoryMock
            .Setup(repo => repo.SaveToFile(It.IsAny<List<Contact>>()))
            .Callback<List<Contact>>(list => contacts = list);// Mock SaveContactToFile
        //Act 
        var result = _contactService.AddContact(form);// This will call CreateContact

        //Assert
        Assert.True(result);
        _contactRepositoryMock.Verify(repo => repo.SaveToFile(It.IsAny<List<Contact>>()), Times.Once);// Verify that SaveContactToFile was called once
    }
    [Fact]
    public void GetFormFile_ShouldReturnDeserializedContactList_WhenFileIsValid()
    {
        //Arrange
        var jsonMock = new List<Contact>
        {
           new Contact {FirstName = "Rafeef",LastName = "Khalifa",Email = "rafeef@domin.com",PhoneNumber = "1234567890",StreetAddress = "123 Main st",ZipCode = "12345",Locality = "Cityville" }
        };

        _contactRepositoryMock.Setup(s => s.GetFormFile()).Returns(jsonMock);

        //Act
        var result = _contactService.GetAllContacts();
        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Rafeef", result[0].FirstName);
        Assert.Equal("Khalifa", result[0].LastName);
        Assert.Equal("rafeef@domin.com", result[0].Email);
        _contactRepositoryMock.Verify(repo => repo.GetFormFile(), Times.Once);
    }
}