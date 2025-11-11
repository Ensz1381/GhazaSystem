

namespace GhazaSystem.Common.Data;

public class User : BasiceData
{
    public required string First_Name { get; set; }
    public required string Last_Name { get; set; }
    public required long National_Code { get; set; }
    public IEnumerable<Daily_Food>? Daily_Foods { get; set; }
    public IEnumerable<Login>? Logins { get; set; }

}


