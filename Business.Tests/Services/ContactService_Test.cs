
using System.Reflection.Emit;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Test
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    private readonly Mock<IFileService> _fileServiceFalseMock;
    private readonly IContactService _contactServiceFalse;
    public ContactService_Test()
    {
        // Mock IFileService
        _fileServiceMock = new Mock<IFileService>();
        // Mock LoadListFromFile för att returnera en tom lista vid initialisering
        _fileServiceMock.Setup(fs => fs.LoadListFromFile()).Returns(new List<Contact>());
        // Skapa ContactService med den mockade IFileService
        _contactService = new ContactService(_fileServiceMock.Object);

        _fileServiceFalseMock = new Mock<IFileService>();
        _contactServiceFalse = new ContactService(_fileServiceFalseMock.Object);
    }
    [Fact]
    public void AddContact_ShouldAddContactToList_AndSaveToFile()
    {
        //Arrange
        var contactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        // Mock SaveContactToFile to return true (save to file)
        _fileServiceMock
            .Setup(fs => fs.SaveContactToFile(It.IsAny<List<Contact>>()))
            .Returns(true);

        //Act 
         _contactService.AddContact(contactRegistrationForm);// This will call CreateContact

        //Assert
        _fileServiceMock.Verify(fs => fs.SaveContactToFile(It.IsAny<List<Contact>>()), Times.Once);// Verify that SaveContactToFile was called once
        // Verify that the contact has been added to the internal list of contacts
        var contacts = _contactService.GetAllContacts();// Assuming you have this getter in ContactService

        Assert.Equal("Rafeef", contacts.First().FirstName);
        Assert.Equal("Khalifa", contacts.First().LastName);
        Assert.Equal("rafeef@domin.com", contacts.First().Email);
        Assert.Equal("1234567890", contacts.First().PhoneNumber);
        Assert.Equal("123 Main st", contacts.First().StreetAddress);
        Assert.Equal("12345", contacts.First().ZipCode);
        Assert.Equal("Cityville", contacts.First().Locality);
    }
    [Fact]
    public void Unsuccessful_AddContact()
    {
        //Arrange
        var contactRegistrationForm = new ContactRegistrationForm()
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        // Mock SaveContactToFile to return true (save to file)
        _fileServiceFalseMock
            .Setup(fs => fs.SaveContactToFile(It.IsAny<List<Contact>>()))
            .Returns(false);

        //Act 
        _contactServiceFalse.AddContact(contactRegistrationForm);

        //Assert
        _fileServiceFalseMock.Verify(fs => fs.SaveContactToFile(It.IsAny<List<Contact>>()), Times.Never);// Verify that SaveContactToFile was not called once
    }
    [Fact]
    public void GetAllContacts_ShouldReturenAllContacts()
    {
        //Arrange
        var expectedContacts = new List<Contact>
        { 
            new Contact
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        },
              new Contact
        {
            FirstName = "Adnan",
            LastName = "Al Kharfan",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        }
        };
        // Mock SaveContactToFile to return true (save to file)
        _fileServiceMock
            .Setup(fs => fs.LoadListFromFile())
            .Returns(expectedContacts);

        //Act 
        var contacts = _contactService.GetAllContacts();
        //Assert
        
        Assert.Equal(2, contacts.Count());
        Assert.Equal("Rafeef", contacts.First().FirstName);
    }
}
