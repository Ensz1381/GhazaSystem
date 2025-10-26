using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Infrastructure.Data;

public class Food_Change : BasiceData
{
    public Daily_Food Food_Changed { get; set; }
    public Type_Of_Change Type_of_changes { get; set; }
}
public class Food_ChangeConfiguration : IEntityTypeConfiguration<Food_Change>
{
    public void Configure(EntityTypeBuilder<Food_Change> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Food_Changed);

    }
}




public enum Type_Of_Change
{
    Select = 0,
    Delete = 1,
    Modify = 2
}