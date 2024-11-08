using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            // Primary Key
            builder.HasKey(i => i.Id);
            // Required and max length 50
            builder.Property(i => i.Name).IsRequired().HasMaxLength(50);
            // Configure CreatedDate to be set automatically
            builder.Property(r => r.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            // Configure Calorie to have a specific SQL Server column type
            builder.Property(r => r.Calorie)
                .HasColumnType("decimal(18,2)");

            builder.HasData(
                new Ingredient { Id = 1, Name = "Domates", Calorie = 20 },
                new Ingredient { Id = 2, Name = "Biber", Calorie = 30 },
                new Ingredient { Id = 3, Name = "Soğan", Calorie = 10 }
            );
        }
    }
}