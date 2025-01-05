using Moq;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace Shared.Test.Services;

public class ContactService_Test
{
    
    private readonly Mock<IFileService> _mockFileService;
    private readonly ContactService _contactService;

    public ContactService_Test()
    {
        // Mock file service
        _mockFileService = new Mock<IFileService>();
        _contactService = new ContactService(_mockFileService.Object);
    }
    [Fact]
    public void AddContactToList_ValidForm_AddsContact()
    {
        // Arrange
        var form = new ContactRegistrationForm
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main St",
            ZipCode = "12345",
            City = "Cityville"
        };

        // Act
        var result = _contactService.AddContactToList(form);

        // Assert
        Assert.True(result); // Ensure the method returned true
        Assert.Single(_contactService.Contacts); // Ensure one contact was added
        _mockFileService.Verify(fs => fs.SaveContactToFile(It.IsAny<List<ContactPersone>>()), Times.Once); // Ensure SaveContactToFile was called
    }
    [Fact]
    public void GetAllContacts_ContactsLoadedSuccessfully_ReturnsContacts()
    {
        // Arrange
        var mockContacts = new List<ContactPersone>
    {
        new ContactPersone
        {
            Id = "1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main St",
            ZipCode = "12345",
            City = "Cityville"
        },
        new ContactPersone
        {
            Id = "2",
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            PhoneNumber = "0987654321",
            StreetAddress = "456 Another St",
            ZipCode = "54321",
            City = "Townsville"
        }
    };

        _mockFileService
            .Setup(fs => fs.LoadListFromFile())
            .Returns(mockContacts);

        // Act
        var result = _contactService.GetAllContacts();

        // Assert
        Assert.NotNull(result); // Ensure the result is not null
        Assert.Equal(mockContacts.Count, result.Count()); // Ensure the correct number of contacts is returned
        Assert.Equal(mockContacts, result); // Ensure the result matches the mock contacts
        _mockFileService.Verify(fs => fs.LoadListFromFile(), Times.Once); // Ensure LoadListFromFile was called once
    }
    [Fact]
    public void RemoveContactFromList_ValidContact_RemovesContactSuccessfully()
    {
        // Arrange
        var mockContact = new ContactPersone { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main St",
            ZipCode = "12345",
            City = "Cityville"
        };
        Contacts.Add(mockContact);

        var form = new ContactRegistrationForm { Id = "1" };

        _mockFileService
            .Setup(fs => fs.RemoveContactfromFile(It.IsAny<List<ContactPersone>>()))
            .Verifiable();

        // Act
        var result = _contactService.RemoveContactFromList(form);

        // Assert
        Assert.True(result); // Metoden returnerar true
        Assert.Empty(Contacts); // Kontakten är borttagen från listan
        _mockFileService.Verify(fs => fs.RemoveContactfromFile(It.Is<List<ContactPersone>>(l => !l.Contains(mockContact))), Times.Once);
    }

}
