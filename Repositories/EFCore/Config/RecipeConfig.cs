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

            builder.HasOne(r => r.Category)
                 .WithMany(c => c.Recipes)
                 .HasForeignKey(r => r.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.RecipeInstructions)
                   .WithOne(ri => ri.Recipe)
                   .HasForeignKey(ri => ri.RecipeId);

            builder.HasOne(r => r.User)
               .WithMany(u => u.Recipes)
               .HasForeignKey(r => r.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Medias)
               .WithOne(m => m.Recipe)
               .HasForeignKey(m => m.RecipeId)
               .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
                new Recipe { Id = 1, Title = "Menemen", Description = "Menemen Menemen pişmandır yemeyen.", CategoryId = 1, Calorie = 200, UserId = "9825bdbb-101d-49c0-82c8-6c4f54b93253" },
                new Recipe { Id = 2, Title = "Pilav", Description = "Tereyağlı pilavdır", CategoryId = 3, Calorie = 300, UserId = "9825bdbb-101d-49c0-82c8-6c4f54b93253" },
                new Recipe { Id = 3, Title = "Çorba", Description = "Çorba severim.", CategoryId = 1, Calorie = 150, UserId = "9825bdbb-101d-49c0-82c8-6c4f54b93253" }
            );
        }
    }
}