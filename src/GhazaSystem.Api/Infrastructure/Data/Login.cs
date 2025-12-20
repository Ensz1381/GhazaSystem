using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;
using GhazaSystem.Common.Data;

namespace GhazaSystem.Api.Infrastructure.Data;


public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Food_Changes);

    }
}