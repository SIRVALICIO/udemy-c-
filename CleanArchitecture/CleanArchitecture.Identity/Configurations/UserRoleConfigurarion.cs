using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfigurarion : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {

                    RoleId = "e8aeef76-c555-44e9-a961-4422fda03748",
                    UserId = "812e5689-2f65-4ca5-a4fb-dd8c9ca2286c"


                },
                new IdentityUserRole<string>
                {

                    RoleId = "fcbfc740-8868-4a4e-845b-ed2fe45e8d6d",
                    UserId = "812e5689-2f65-4ca5-a4fb-dd8c9ca2286c"


                }
            );

        }
    }
}
