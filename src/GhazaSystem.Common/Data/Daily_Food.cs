
namespace GhazaSystem.Common.Data;

public class Daily_Food: BasiceData
{

    public Guid foodId { get; set; }
    public Food? food { get; set; } 
    public  DateOnly Date { get; set; }
    public List<User>? users { get; set; }

    public int Mount { get; set; }


}
