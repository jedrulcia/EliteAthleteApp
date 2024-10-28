using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EliteAthleteApp.Constants;

namespace EliteAthleteApp.Configurations.Entities
{
    // SEED CONFIGURATION FOR INITIAL USER ROLES IN THE DATABASE, INCLUDING ADMIN AND USER ROLES.
	public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "543bced5-375b-5291-0a59-1dc59923d1b0",
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpper()
                },
                new IdentityRole
                {
                    Id = "543bced5-375b-5291-0a59-1dc59923d1b1",
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpper()
                },
				new IdentityRole
				{
					Id = "543bced5-375b-5291-0a59-1dc59923d1b2",
					Name = Roles.Coach,
					NormalizedName = Roles.Coach.ToUpper()
				}
				);
        }
    }
}