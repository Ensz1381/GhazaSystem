using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Infrastructure.Data;

public class User : BasiceData
{
    public required string First_Name { get; set; }
    public required string Last_Name { get; set; }
    public required long National_Code { get; set; }
    public IEnumerable<Daily_Food>? Daily_Foods { get; set; }
    public IEnumerable<Login>? Logins { get; set; }

}
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Daily_Foods);
        builder.HasMany(x => x.Logins);

    }
}

