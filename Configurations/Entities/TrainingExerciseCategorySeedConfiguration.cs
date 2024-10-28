using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL EXERCISE CATEGORIES IN THE DATABASE.
	public class TrainingExerciseCategorySeedConfiguration : IEntityTypeConfiguration<TrainingExerciseCategory>
	{
		public void Configure(EntityTypeBuilder<TrainingExerciseCategory> builder)
		{
			builder.HasData(
				new TrainingExerciseCategory { Id = 1, Name = "Conditioning" },
				new TrainingExerciseCategory { Id = 2, Name = "Strength" },
				new TrainingExerciseCategory { Id = 3, Name = "Mobility" },
				new TrainingExerciseCategory { Id = 4, Name = "Stretching" },
				new TrainingExerciseCategory { Id = 5, Name = "Plyometrics" },
				new TrainingExerciseCategory { Id = 6, Name = "Dynamics" },
				new TrainingExerciseCategory { Id = 7, Name = " " }
				);
		}
	}
}
