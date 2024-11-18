using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.RecipeId).IsRequired();
            builder.Property(i => i.IngredientId).IsRequired();
            builder.Property(i => i.CreatedDate).HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new RecipeIngredient { Id = 1, RecipeId = 1, IngredientId = 1, Quantity = 2, Unit = "adet" },
                new RecipeIngredient { Id = 2, RecipeId = 1, IngredientId = 2, Quantity = 3, Unit = "adet" },
                new RecipeIngredient { Id = 3, RecipeId = 1, IngredientId = 3, Quantity = 1, Unit = "adet" }
            );
        }
    }
}