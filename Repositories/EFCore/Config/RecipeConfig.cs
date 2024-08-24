using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasData([
                new Recipe { Id = 1, Title = "Menemen", Calorie = 200 },
                new Recipe { Id = 2, Title = "Pilav", Calorie = 300 },
                new Recipe { Id = 3, Title = "Çorba", Calorie = 150 },
            ]);
        }
    }
}