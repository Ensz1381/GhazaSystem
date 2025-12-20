using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GhazaSystem.Common.Data;

namespace GhazaSystem.Api.Infrastructure.Data;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Daily_Foods)
            .WithMany(x=>x.users);
 
        builder.HasMany(x => x.Logins);

    }
}

