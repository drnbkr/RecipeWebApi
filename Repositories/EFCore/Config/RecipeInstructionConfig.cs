using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RecipeInstructionConfig : IEntityTypeConfiguration<RecipeInstruction>
    {
        public void Configure(EntityTypeBuilder<RecipeInstruction> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.RecipeId).IsRequired();
            builder.Property(i => i.Step).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.CreatedDate).HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new RecipeInstruction { Id = 1, RecipeId = 1, Step = 1, Description = "Fırını 180 dereceye ayarlayın." },
                new RecipeInstruction { Id = 2, RecipeId = 1, Step = 2, Description = "Un, kabartma tozu ve tuzu karıştırın." },
                new RecipeInstruction { Id = 3, RecipeId = 1, Step = 3, Description = "Yumurtaları çırpın." }
            );


        }
    }
}