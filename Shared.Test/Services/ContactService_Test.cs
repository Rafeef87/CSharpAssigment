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
    /* Detta är genererat av Chat GPT 4o - Denna kod testa att kontact adding  Successfully*/


    [Fact]
    public void AddContactToList_Successfully_AddsContact()
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
        Assert.Single(_contactService.contacts); // Ensure one contact was added
        _mockFileService.Verify(fs => fs.SaveContactToFile(It.IsAny<List<ContactPersone>>()), Times.Once); // Ensure SaveContactToFile was called
    }

    /* Detta är genererat av Chat GPT 4o - Denna kod testa hämta all contact list Successfully */


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
    /* Detta är genererat av Chat GPT 4o - Denna kod testa Update contact Successfully */
    [Fact]
    public void GetContactById_ShouldReturnContact_WhenIdExists()
    {
        // Arrange
        var contactId = Guid.NewGuid();
        var contact = new ContactPersone
        {
            Id = contactId.ToString(),
            FirstName = "John",
            LastName = "Doe"
        };
        _contactService.contacts.Add(contact);

        // Act
        var result = _contactService.GetContactById(contactId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(contactId.ToString(), result.Id);
        Assert.Equal("John", result.FirstName);
    }
    [Fact]
    public void Update_ShouldSuccessfully_UpdatesContact()
    {
        // Arrange
        var contact = new ContactPersone
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "John",
            LastName = "Doe"
        };
        _contactService.contacts.Add(contact);

        var updatedForm = new ContactRegistrationForm
        {
            Id = contact.Id,
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            PhoneNumber = "123456789",
            StreetAddress = "123 Main St",
            ZipCode = "12345",
            City = "Metropolis"
        };

        // Act
        var result = _contactService.Update(updatedForm);

        // Assert
        Assert.True(result);
        Assert.Equal("Jane", contact.FirstName);
        Assert.Equal("Smith", contact.LastName);
        Assert.Equal("jane.smith@example.com", contact.Email);
        _mockFileService.Verify(fs => fs.SaveContactToFile(It.IsAny<List<ContactPersone>>()), Times.Once);
        _mockFileService.Verify(fs => fs.LoadListFromFile(), Times.Once);
    }
    [Fact]
    public void Update_ShouldTriggerContactListaUpdateEvent_WhenContactIsUpdated()
    {
        // Arrange
        var contact = new ContactPersone
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "John"
        };
        _contactService.contacts.Add(contact);

        var updatedForm = new ContactRegistrationForm
        {
            Id = contact.Id,
            FirstName = "Jane"
        };

        bool eventTriggered = false;
        _contactService.ContactListaUpdate += (sender, args) => eventTriggered = true;

        // Act
        var result = _contactService.Update(updatedForm);

        // Assert
        Assert.True(result);
        Assert.True(eventTriggered);
    }
    /* Detta är genererat av Chat GPT 4o - Denna kod testa remove contact Successfully */
    [Fact]
    public void RemoveContactFromList_ShouldRemoveContact_WhenContactExists()
    {
        // Arrange
        var contact = new ContactPersone
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main St",
            ZipCode = "12345",
            City = "Cityville"
        };
        _contactService.contacts.Add(contact);

        var contactForm = new ContactRegistrationForm
        {
            Id = contact.Id
        };

        // Act
        var result = _contactService.RemoveContactFromList(contactForm);

        // Assert
        Assert.True(result);
        
        _mockFileService.Verify(fs => fs.RemoveContactfromFile(It.IsAny<List<ContactPersone>>()), Times.Once);
    }

    [Fact]
    public void RemoveContactFromList_ShouldTriggerContactListaUpdateEvent_WhenContactIsRemoved()
    {
        // Arrange
        var contact = new ContactPersone
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = "John"
        };
        _contactService.contacts.Add(contact);

        var contactForm = new ContactRegistrationForm
        {
            Id = contact.Id
        };

        bool eventTriggered = false;
        _contactService.ContactListaUpdate += (sender, args) => eventTriggered = true;

        // Act
        _contactService.RemoveContactFromList(contactForm);

        // Assert
        Assert.True(eventTriggered);
    }
    [Fact]
    public void RemoveContactFromList_ShouldReturnFalse_WhenFormIsNull()
    {
        // Act
        var result = _contactService.RemoveContactFromList(null);

        // Assert
        Assert.False(result);
        _mockFileService.Verify(fs => fs.RemoveContactfromFile(It.IsAny<List<ContactPersone>>()), Times.Never);
    }
}
