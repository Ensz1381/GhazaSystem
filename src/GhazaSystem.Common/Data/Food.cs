

namespace GhazaSystem.Common.Data;

public class Food : BasiceData
{
    public required string Name { get; set; }
    public required float Amount { get; set; }
    public string? Photos { get; set; }
    public string? Description { get; set; }

}
