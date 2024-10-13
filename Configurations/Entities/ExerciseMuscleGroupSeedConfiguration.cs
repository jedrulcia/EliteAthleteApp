using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL EXERCISE MUSCLE GROUPS IN THE DATABASE.
	public class ExerciseMuscleGroupSeedConfiguration : IEntityTypeConfiguration<ExerciseMuscleGroup>
	{
		public void Configure(EntityTypeBuilder<ExerciseMuscleGroup> builder)
		{
			builder.HasData(
				new ExerciseMuscleGroup { Id = 1, Name = " " },
				new ExerciseMuscleGroup { Id = 2, Name = "Neck" },
				new ExerciseMuscleGroup { Id = 3, Name = "Shoulders" },
				new ExerciseMuscleGroup { Id = 4, Name = "Chest" },
				new ExerciseMuscleGroup { Id = 5, Name = "Core" },
				new ExerciseMuscleGroup { Id = 6, Name = "Biceps" },
				new ExerciseMuscleGroup { Id = 7, Name = "Triceps" },
				new ExerciseMuscleGroup { Id = 8, Name = "Forearms/Wrist" },
				new ExerciseMuscleGroup { Id = 9, Name = "Back" },
				new ExerciseMuscleGroup { Id = 11, Name = "Glutes" },
				new ExerciseMuscleGroup { Id = 12, Name = "Lower Back" },
				new ExerciseMuscleGroup { Id = 13, Name = "Quadriceps" },
				new ExerciseMuscleGroup { Id = 14, Name = "Hamstrings" },
				new ExerciseMuscleGroup { Id = 15, Name = "Calves" }
			);
		}
	}
}
