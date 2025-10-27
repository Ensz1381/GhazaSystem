using GhazaSystem.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GhazaSystem.Api.Infrastructure.Data
{
    public class Daily_Food: BasiceData
    {
        public required Food food { get; set; }
        public required DateOnly Date { get; set; }


    }
}
public class Daily_FoodConfiguration : IEntityTypeConfiguration<Daily_Food>
{
    public void Configure(EntityTypeBuilder<Daily_Food> builder)
    {
        builder.HasKey(x => x.Id);


    }
}