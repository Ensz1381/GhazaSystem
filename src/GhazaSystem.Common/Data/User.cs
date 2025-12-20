

namespace GhazaSystem.Common.Data;

public class User : BasiceData
{
    public  string? First_Name { get; set; }
    public  string? Last_Name { get; set; }
    public  long National_Code { get; set; }
    public List<Daily_Food>? Daily_Foods { get; set; }
    public IEnumerable<Login>? Logins { get; set; }

}


