
namespace GhazaSystem.UI.Shared;

public static class UserUrlApi
{
    public const string add = "api/User/add";
    public const string all = "api/User/all";
    public const string update = "api/User/update";
    public const string updateDailyFood = "api/User/updatedaily";
    public const string SetAccessUser = "api/User/setaccess";
    public static string delete (Guid id)
    {
        return $"api/User/delete/{id}";
    }
    public static string getId(Guid id)
    {
        return $"api/User/get/{id}";
    }
    public static string getCode(long code)
    {
        return $"api/User/national-code/{code}";
    }
}
