
using GhazaSystemCommon.Data;
using System.Threading.Channels;

namespace GhazaSystem.Common.Data;

public class Login : BasiceData
{
    public Guid User_Id { get; set; }
    public DateOnly Date { get; set; }
    public required string Ip_Login { get; set; }
    public IEnumerable<Food_Change>? Food_Changes { get; set; }
    public DateTime Time { get; set; }


}
