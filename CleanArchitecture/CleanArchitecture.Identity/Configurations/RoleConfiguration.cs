using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(

                new IdentityRole
                {
                    Id = "e8aeef76-c555-44e9-a961-4422fda03748",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                ,
                   new IdentityRole
                   {
                       Id = "fcbfc740-8868-4a4e-845b-ed2fe45e8d6d",
                       Name = "Operator",
                       NormalizedName = "OPERATOR"
                   }


                );
        }
    }
}
