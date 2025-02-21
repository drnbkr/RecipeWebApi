using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class MediaConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.Id); ;
            builder.Property(m => m.MediaPath).IsRequired();
            builder.Property(m => m.MediaType).IsRequired();
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("GETDATE()");


            // Recipe ile ilişki (optional)
            builder.HasOne(m => m.Recipe)
               .WithMany(r => r.Medias)
               .HasForeignKey(m => m.RecipeId)
               .IsRequired(false); // RecipeId null olabilir

            builder.HasOne(m => m.RecipeInstruction)
               .WithMany(ri => ri.Medias)
               .HasForeignKey(m => m.RecipeInstructionId)
               .IsRequired(false);

            builder.HasData(
                new Media { Id = 1, RecipeInstructionId = 1, MediaPath = "https://via.placeholder.com/150", MediaType = "image" },
                new Media { Id = 2, RecipeInstructionId = 2, MediaPath = "https://via.placeholder.com/150", MediaType = "image" },
                new Media { Id = 3, RecipeInstructionId = 3, MediaPath = "https://via.placeholder.com/150", MediaType = "image" }
            );
        }
    }
}