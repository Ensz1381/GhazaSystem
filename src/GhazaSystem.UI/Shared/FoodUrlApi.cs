namespace GhazaSystem.UI.Shared
{
    public static class FoodUrlApi
    {
        public const string add = "api/food/add";
        public const string all = "api/food/all";
        public const string update = "api/food/update";
        public static string delete(Guid id)
        {
            return $"api/food/delete/{id}";
        }
        public static string getId(Guid id)
        {
            return $"api/food/get/{id}";
        }
    }
}
