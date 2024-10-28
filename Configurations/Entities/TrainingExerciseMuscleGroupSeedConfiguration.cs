using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL EXERCISE MUSCLE GROUPS IN THE DATABASE.
	public class TrainingExerciseMuscleGroupSeedConfiguration : IEntityTypeConfiguration<TrainingExerciseMuscleGroup>
	{
		public void Configure(EntityTypeBuilder<TrainingExerciseMuscleGroup> builder)
		{
			builder.HasData(
				new TrainingExerciseMuscleGroup { Id = 1, Name = " " },
				new TrainingExerciseMuscleGroup { Id = 2, Name = "Neck" },
				new TrainingExerciseMuscleGroup { Id = 3, Name = "Shoulders" },
				new TrainingExerciseMuscleGroup { Id = 4, Name = "Chest" },
				new TrainingExerciseMuscleGroup { Id = 5, Name = "Core" },
				new TrainingExerciseMuscleGroup { Id = 6, Name = "Biceps" },
				new TrainingExerciseMuscleGroup { Id = 7, Name = "Triceps" },
				new TrainingExerciseMuscleGroup { Id = 8, Name = "Forearms/Wrist" },
				new TrainingExerciseMuscleGroup { Id = 9, Name = "Back" },
				new TrainingExerciseMuscleGroup { Id = 11, Name = "Glutes" },
				new TrainingExerciseMuscleGroup { Id = 12, Name = "Lower Back" },
				new TrainingExerciseMuscleGroup { Id = 13, Name = "Quadriceps" },
				new TrainingExerciseMuscleGroup { Id = 14, Name = "Hamstrings" },
				new TrainingExerciseMuscleGroup { Id = 15, Name = "Calves" },
				new TrainingExerciseMuscleGroup { Id = 16, Name = "Trapezius" },
				new TrainingExerciseMuscleGroup { Id = 17, Name = "Adductors" },
				new TrainingExerciseMuscleGroup { Id = 18, Name = "Abductors" }
			);
		}
	}
}
