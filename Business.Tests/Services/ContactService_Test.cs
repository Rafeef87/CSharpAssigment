
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Test
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Test()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }
    [Fact]
    public void CreateContact_ShouldAddContactToList_AndSaveToFile()
    {
        //Arrange
        var contactRegistrationForm = new ContactRegistrationForm
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
        _fileServiceMock
            .Setup(fs => fs.SaveContactToFile(It.IsAny<List<Contact>>()))
            .Verifiable();// Just verifying that this method is called

        //Act 
         _contactService.Add(contactRegistrationForm);// This will call CreateContact

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
}
