using GhazaSystem.Api.Infrastructure.Data;

namespace GhazaSystem.Api.DTOs;

public class LoginDTOs
{
    public DateOnly Date { get; set; }
    public required string Ip_Login { get; set; }
    public IEnumerable<Food_Change>? Food_Changes { get; set; }
}
