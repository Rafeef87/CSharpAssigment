using Business.Interfaces;
using Business.Models;
using Business.Repositories;

using Moq;

namespace Business.Tests.Repositories;

    public class ContactRepository_Test
    {
        private readonly Mock<IContactFileService> _contactFileServiceMock;
        private readonly ContactRepository _contactRepository;
        public ContactRepository_Test()
        {
            // Mock IFileService
            _contactFileServiceMock = new Mock<IContactFileService>();
       
            // Skapa ContactService med den mockade IFileService
            _contactRepository = new ContactRepository(_contactFileServiceMock.Object);
        }
        [Fact]
        public void GetFormFile_ShouldReturnDeserializedContactList_WhenFileIsValid()
        {
            //Arrange
            var jsonMock = "[{\"FirstName\":\"Rafeef\",\"LastName\":\"Khalifa\",\"Email\":\"rafeef@domin.com\",\"PhoneNumber\":\"1234567890\"}]";


            _contactFileServiceMock.Setup(s => s.LoadListFromFile()).Returns(jsonMock);
       
            //Act
            var result = _contactRepository.GetFormFile();
            //Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Rafeef", result[0].FirstName);
            Assert.Equal("Khalifa", result[0].LastName);
            Assert.Equal("rafeef@domin.com", result[0].Email);

        }
        [Fact]
        public void SaveToFile_ShouldSaveCorrectly_WhenGivenValidContactList()
        {
            //Arrange
            var expectedContacts = new List<Contact>
            { 
                new() {
                FirstName = "Rafeef",
                LastName = "Khalifa",
                Email = "rafeef@domin.com",
                PhoneNumber = "1234567890",
                StreetAddress = "123 Main st",
                ZipCode = "12345",
                Locality = "Cityville"
            }
            };
            // Mock GetFormFile to return an empty list initially
            _contactFileServiceMock.Setup(s => s.SaveContactToFile(It.IsAny<string>()));
   
            //Act 
            var contacts = _contactRepository.SaveToFile(expectedContacts);
            //Assert 
            _contactFileServiceMock.Verify(s => s.SaveContactToFile(It.IsAny<string>()));
            Assert.True(contacts);
        }
    }

