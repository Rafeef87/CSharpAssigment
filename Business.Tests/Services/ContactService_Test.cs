
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
        var contactRegistrationForm = new ContactRegistrationForm();
        _fileServiceMock
            .Setup(fs => fs.SaveContactToFile(It.IsAny<string>()))
            .Returns(true);// Mock SaveContactToFile

        //Act 
        var result = _contactService.Add(contactRegistrationForm);// This will call CreateContact

        //Assert
        Assert.True(result);
        _fileServiceMock.Verify(fs => fs.SaveContactToFile(It.IsAny<string>()), Times.Once);// Verify that SaveContactToFile was called once
    }
}
