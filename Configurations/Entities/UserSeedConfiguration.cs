using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<User>
	{
		// SEED CONFIGURATION FOR INITIAL USER ACCOUNTS IN THE DATABASE.
		public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "654bced5-375b-5291-0a59-1dc59923d1b0",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "Admin",
                    LastName = "System",
                    PasswordHash = hasher.HashPassword(null, "Admin!2"),
                    EmailConfirmed = true,
					CoachId = "654bced5-375b-5291-0a59-1dc59923d1b0",
                    UserSubscriptionId = 4
				},
                new User
                {
                    Id = "654bced5-375b-5291-0a59-1dc59923d1b1",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "User",
                    LastName = "System",
                    PasswordHash = hasher.HashPassword(null, "Admin!2"),
                    EmailConfirmed = true,
                    UserSubscriptionId = 1
				},
				new User
				{
					Id = "654bced5-375b-5291-0a59-1dc59923d1b2",
					UserName = "coach@localhost.com",
					NormalizedUserName = "COACH@LOCALHOST.COM",
					Email = "coach@localhost.com",
					NormalizedEmail = "COACH@LOCALHOST.COM",
					FirstName = "Coach",
					LastName = "System",
					PasswordHash = hasher.HashPassword(null, "Admin!2"),
					EmailConfirmed = true,
                    CoachId = "654bced5-375b-5291-0a59-1dc59923d1b2",
                    UserSubscriptionId = 3
				}
				);
        }
    }
}