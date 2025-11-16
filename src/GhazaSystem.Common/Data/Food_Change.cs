

namespace GhazaSystem.Common.Data;

public class Food_Change : BasiceData
{
    public required Daily_Food Food_Changed { get; set; }
    public required Type_Of_Change Type_of_changes { get; set; }
}



public enum Type_Of_Change
{
    Select = 0,
    Delete = 1,
    Modify = 2
}