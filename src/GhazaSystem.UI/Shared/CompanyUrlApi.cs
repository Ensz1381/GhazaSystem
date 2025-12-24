namespace GhazaSystem.UI.Shared;

public class CompanyUrlApi
{
    public const string add = "api/Company/add";
    public const string all = "api/Company/all";
    public const string update = "api/Company/update";
    public static string delete(Guid id)
    {
        return $"api/Company/delete/{id}";
    }
    public static string getId(Guid id)
    {
        return $"api/Company/get/{id}";
    }
    public static string getCode(long code)
    {
        return $"api/Company/code/{code}";
    }
}
