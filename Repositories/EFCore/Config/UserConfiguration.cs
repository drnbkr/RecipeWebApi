using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = "9825bdbb-101d-49c0-82c8-6c4f54b93253",
                    UserName = "drnbkr",
                    NormalizedUserName = "ADMIN",
                    Email = "direnbukre@gmail.com",
                    NormalizedEmail = "DIRENBUKRE@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123456"),
                    SecurityStamp = string.Empty
                }
            );
        }
    }
}