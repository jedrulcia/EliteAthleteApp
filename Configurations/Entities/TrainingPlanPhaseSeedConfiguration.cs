using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL TRAINING PLAN PHASES IN THE DATABASE.
	public class TrainingPlanPhaseSeedConfiguration : IEntityTypeConfiguration<TrainingPlanPhase>
	{
		public void Configure(EntityTypeBuilder<TrainingPlanPhase> builder)
		{
			builder.HasData(
				new TrainingPlanPhase { Id = 1, Name = " " },
				new TrainingPlanPhase { Id = 2, Name = "Warm-up" },
				new TrainingPlanPhase { Id = 3, Name = "Mobility" },
				new TrainingPlanPhase { Id = 4, Name = "Strength Training" },
				new TrainingPlanPhase { Id = 5, Name = "Core Training" },
				new TrainingPlanPhase { Id = 6, Name = "Cardio/Conditioning" },
				new TrainingPlanPhase { Id = 7, Name = "Cool Down" },
				new TrainingPlanPhase { Id = 8, Name = "Stretching" }
			);
		}
	}
}
