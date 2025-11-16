namespace GhazaSystem.UI.Shared
{
    public class LoginUrlApi
    {
        public const string add = "api/Login/add";
        public const string all = "api/Login/all";
        public const string update = "api/Login/update";
        public static string delete(Guid id)
        {
            return $"api/Login/delete/{id}";
        }
        public static string getId(Guid id)
        {
            return $"api/Login/get/{id}";
        }
    }
}
