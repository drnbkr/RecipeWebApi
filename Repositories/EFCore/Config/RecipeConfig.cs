using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
             // Configure CreatedDate to be set automatically
            builder.Property(r => r.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            // Configure Calorie to have a specific SQL Server column type
            builder.Property(r => r.Calorie)
                .HasColumnType("decimal(18,2)");
                
            builder.HasData(
                new Recipe { Id = 1, CategoryId = 1, Title = "Menemen", Calorie = 200 },
                new Recipe { Id = 2, CategoryId = 3, Title = "Pilav", Calorie = 300 },
                new Recipe { Id = 3, CategoryId = 1, Title = "Çorba", Calorie = 150 }
            );
        }
    }
}