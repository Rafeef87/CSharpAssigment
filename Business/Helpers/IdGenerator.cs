
namespace Business.Helpers;

public static class IdGenerator
{
    public static string GenerateUniqueIdd()
    {
        return Guid.NewGuid().ToString();
    }
}
