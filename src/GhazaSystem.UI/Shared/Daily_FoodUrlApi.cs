namespace GhazaSystem.UI.Shared
{
    public class Daily_FoodUrlApi
    {
        public const string add = "api/Daily_Food/add";
        public const string all = "api/Daily_Food/all";
        public const string update = "api/Daily_Food/update";
        public static string delete(Guid id)
        {
            return $"api/Daily_Food/delete/{id}";
        }
        public static string getId(Guid id)
        {
            return $"api/Daily_Food/get/{id}";
        }
    }
}
