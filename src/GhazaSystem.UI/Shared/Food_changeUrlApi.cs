namespace GhazaSystem.UI.Shared
{
    public class Food_changeUrlApi
    {
        public const string add = "api/food_change/add";
        public const string all = "api/food_change/all";
        public const string update = "api/food_change/update";
        public static string delete(Guid id)
        {
            return $"api/food_change/delete/{id}";
        }
        public static string getId(Guid id)
        {
            return $"api/food_change/get/{id}";
        }
    }
}
