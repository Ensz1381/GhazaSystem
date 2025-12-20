
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GhazaSystem.Common.Data;


public class Daily_FoodConfiguration : IEntityTypeConfiguration<Daily_Food>
{
    public void Configure(EntityTypeBuilder<Daily_Food> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.food)
            .WithMany()
            .HasForeignKey(x => x.foodId);
        builder.HasMany(m => m.users)
            .WithMany(s => s.Daily_Foods);
            
            
    }
}