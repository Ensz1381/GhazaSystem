
namespace GhazaSystem.Common.Data
{
    public class Daily_Food: BasiceData
    {
        public required Food food { get; set; }
        public required DateOnly Date { get; set; }


    }
}
