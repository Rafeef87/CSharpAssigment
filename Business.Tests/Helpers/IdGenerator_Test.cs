using Business.Helpers;

namespace Business.Tests;

public class IdGenerator_Test
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
         //Act
         var result = IdGenerator.GenerateUniqueId();
        //Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
   
    
}
