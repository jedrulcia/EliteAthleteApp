using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EliteAthleteApp.Configurations.Entities
{
    // SEED CONFIGURATION FOR INITIAL USER-ROLE ASSOCIATIONS IN THE DATABASE.
	public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "543bced5-375b-5291-0a59-1dc59923d1b0",
                    UserId = "654bced5-375b-5291-0a59-1dc59923d1b0"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "543bced5-375b-5291-0a59-1dc59923d1b1",
                    UserId = "654bced5-375b-5291-0a59-1dc59923d1b1"
                },
				new IdentityUserRole<string>
				{
					RoleId = "543bced5-375b-5291-0a59-1dc59923d1b2",
					UserId = "654bced5-375b-5291-0a59-1dc59923d1b2"
				},
				new IdentityUserRole<string>
				{
					RoleId = "543bced5-375b-5291-0a59-1dc59923d1b3",
					UserId = "654bced5-375b-5291-0a59-1dc59923d1b3"
				},
				new IdentityUserRole<string>
				{
					RoleId = "543bced5-375b-5291-0a59-1dc59923d1b4",
					UserId = "654bced5-375b-5291-0a59-1dc59923d1b4"
				}
				);
        }
    }
}