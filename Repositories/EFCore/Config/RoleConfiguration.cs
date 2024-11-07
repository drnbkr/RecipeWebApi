using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Id = "b7afb518-6211-47f2-a7cb-95e7b500d74f", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "f16264a2-d99b-4eaf-9052-8a5581e6ab85", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2bcaf9d9-fa5f-4188-811f-4b0268bfde60", Name = "Editor", NormalizedName = "EDITOR" }
            );
        }
    }
}