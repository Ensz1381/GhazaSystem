using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace GhazaSystem.Api.Infrastructure.Data;

public class Login : BasiceData
{
    public Guid User_Id { get; set; }
    public DateOnly Date { get; set; }
    public string Ip_Login { get; set; }
    public IEnumerable<Food_Change> Food_Changes { get; set; }
    public DateTime Time { get; set; }

}
public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Food_Changes);

    }
}