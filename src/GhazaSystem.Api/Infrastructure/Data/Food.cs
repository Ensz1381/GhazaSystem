using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Infrastructure.Data;

public class Food : BasiceData
{
    public required string Name { get; set; }
    public required float Amount { get; set; }
    public string? Photos { get; set; }
    public string? Description { get; set; }

}

public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasKey(x => x.Id);


    }
}