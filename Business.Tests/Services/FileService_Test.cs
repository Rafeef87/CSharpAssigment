

using Business.Interfaces;
using Business.Models;

namespace Business.Tests.Services;

public class FileService_Test
{
    [Fact]
    public void SaveContactToFile_ShouldSaveContactToFile()
    {
        //Arrange
        var contact = "test";
        var fileName = $"{Guid.NewGuid()}.json";
        IFileService fileService = new FileService(fileName);

        try
        {
            //Act
            var result = fileService.SaveContactToFile(contact);
            //Assert
            Assert.True(result);
        }
        finally
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }
    }
    [Fact]
    public void GetContactFromFile_ShouldReturenContactListFromFile()
    {
        //Arrange
        var contact = "test";
        var directoryPath = "TestData";
        var fileName = $"{Guid.NewGuid()}.json";
        var fullFilePath = Path.Combine(directoryPath, fileName);

        //Make sure the folder exists
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);
        File.WriteAllText(fullFilePath, contact);

        IFileService fileService = new FileService(directoryPath, fileName);
      
        try
        {
            //Act
            var result = fileService.LoadListFromFile();
            //Assert
            Assert.Equal(contact, result);
        }
        finally
        {
            if (File.Exists(fullFilePath))
                File.Delete(fullFilePath);


            if (Directory.Exists(directoryPath) && Directory.GetFiles(directoryPath).Length == 0)
                Directory.Delete(directoryPath);
        }

    }
}
