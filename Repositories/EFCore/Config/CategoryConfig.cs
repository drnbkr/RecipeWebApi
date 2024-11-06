using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary Key
            builder.HasKey(c => c.Id);
            // Required and max length 50
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            // Configure CreatedDate to be set automatically
            builder.Property(r => r.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new Category { Id = 1, Name = "Çorbalar" },
                new Category { Id = 2, Name = "Tatlılar" },
                new Category { Id = 3, Name = "Ana Yemekler" },
                new Category { Id = 4, Name = "Meyveli Tatlılar" }
            );
        }
    }
}