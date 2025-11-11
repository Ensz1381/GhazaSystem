
namespace GhazaSystem.UI.Shared;

public static class UserUrlApi
{
    public const string add = "api/user/add";
    public const string all = "api/user/all";
    public const string update = "api/user/update";
    public static string delete (Guid id)
    {
        return $"api/user/delete/{id}";
    }
    public static string getId(Guid id)
    {
        return $"api/user/get/{id}";
    }
    public static string getCode(long code)
    {
        return $"api/user/national-code/{code}";
    }
}
