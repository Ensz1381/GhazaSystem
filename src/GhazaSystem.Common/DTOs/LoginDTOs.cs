

using GhazaSystem.Common.Data;

namespace GhazaSystem.Common.DTOs;

public class LoginDTOs
{
    public DateOnly Date { get; set; }
    public required string Ip_Login { get; set; }
    public IEnumerable<Food_Change>? Food_Changes { get; set; }
}
