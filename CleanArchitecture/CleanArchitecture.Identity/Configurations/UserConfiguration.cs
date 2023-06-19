using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            var hasher= new PasswordHasher<ApplicationUser>();
            builder.HasData(


                new ApplicationUser
                {
                    Id = "812e5689-2f65-4ca5-a4fb-dd8c9ca2286c",
                    Email = "Admin@local.com",
                    NormalizedEmail = "Admin@local.com",
                    Nombre = "Val",
                    Apellidos = "Icio",
                    UserName = "Sirvalicio",
                    NormalizedUserName = "Sirvalicio",
                    PasswordHash = hasher.HashPassword(null, "Esto es una contraseña al revez"),
                    EmailConfirmed = true
                }, new ApplicationUser
                {
                    Id = "97913b19-8469-4960-a0a0-a3cc65d88b8c",
                    Email = "NoAdmin@local.com",
                    NormalizedEmail = "NoAdmin@local.com",
                    Nombre = "Lav",
                    Apellidos = "Oici",
                    UserName = "Lavoici",
                    NormalizedUserName = "UserNameGenrico",
                    PasswordHash = hasher.HashPassword(null, "Esto es una contraseña cifrada"),
                    EmailConfirmed = true
                }


                );
        }
    }
}
