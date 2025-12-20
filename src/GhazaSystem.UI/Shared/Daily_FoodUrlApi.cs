namespace GhazaSystem.UI.Shared
{
    public class Daily_FoodUrlApi
    {
        public const string add = "api/Daily_Food/add";
        public const string addlist = "api/Daily_Food/add/list";
        public const string all = "api/Daily_Food/all";
        public const string update = "api/Daily_Food/update";
        public const string UserDailyFoods = "api/Daily_Food/user";
        public static string delete(Guid id)
        {
            return $"api/Daily_Food/delete/{id}";
        }

        public static string deletemont(int mont)
        {
            return $"api/Daily_Food/delete/mont/{mont}";
        }
        public static string getId(Guid id)
        {
            return $"api/Daily_Food/get/{id}";
        }
        public static string getmont(int mont)
        {
            return $"api/Daily_Food/mont/{mont}";
        }
    }
}
