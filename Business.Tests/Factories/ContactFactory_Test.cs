using Business.Factories;
using Business.Models;

namespace Business.Tests;

public class ContactFactory_Test
{

    [Fact]
    public void Create_ShouldReturnContactRegistrationForm()
    {
        //Act
        var result= ContactFactory.Create();
        //Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegistrationForm>(result);
    }
    [Fact]
    public void CreateContact_ShouldReturnNewContact()
    {
        //Arrange
        var contact = new ContactRegistrationForm()
        {
            FirstName = "Rafeef",
            LastName = "Khalifa",
            Email = "rafeef@domin.com",
            PhoneNumber = "1234567890",
            StreetAddress = "123 Main st",
            ZipCode = "12345",
            Locality = "Cityville"
        };
         //Act
         var result = ContactFactory.Create(contact);
        //Assert
        Assert.NotNull(result);
        Assert.Equal(contact.FirstName, result.FirstName);
        Assert.Equal(contact.LastName, result.LastName);
        Assert.Equal(contact.Email, result.Email);
        Assert.Equal(contact.PhoneNumber, result.PhoneNumber);
        Assert.Equal(contact.StreetAddress, result.StreetAddress);
        Assert.Equal(contact.ZipCode, result.ZipCode);
        Assert.Equal(contact.Locality, result.Locality);

    }
}
