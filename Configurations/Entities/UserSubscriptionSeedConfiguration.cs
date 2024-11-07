using EliteAthleteApp.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EliteAthleteApp.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL TRAINING PLAN PHASES IN THE DATABASE.
	public class UserSubscriptionSeedConfiguration : IEntityTypeConfiguration<UserSubscription>
	{
		public void Configure(EntityTypeBuilder<UserSubscription> builder)
		{
			builder.HasData(
				new UserSubscription { Id = 1, Name = "Athlete", AthleteLimit = 0, PrivateExerciseLimit = 0 },
				new UserSubscription { Id = 2, Name = "Free", AthleteLimit = 3, PrivateExerciseLimit = 5 },
				new UserSubscription { Id = 3, Name = "Basic", AthleteLimit = 10, PrivateExerciseLimit = 20 },
				new UserSubscription { Id = 4, Name = "Premium", AthleteLimit = 200, PrivateExerciseLimit = 200 }
			);
		}
	}
}
