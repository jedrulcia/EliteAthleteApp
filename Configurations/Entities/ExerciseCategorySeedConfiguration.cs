using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL EXERCISE CATEGORIES IN THE DATABASE.
	public class ExerciseCategorySeedConfiguration : IEntityTypeConfiguration<ExerciseCategory>
	{
		public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
		{
			builder.HasData(
				new ExerciseCategory { Id = 1, Name = "Conditioning" },
				new ExerciseCategory { Id = 2, Name = "Strength" },
				new ExerciseCategory { Id = 3, Name = "Mobility" },
				new ExerciseCategory { Id = 4, Name = "Stretching" },
				new ExerciseCategory { Id = 5, Name = "Plyometrics" },
				new ExerciseCategory { Id = 6, Name = "Dynamics" },
				new ExerciseCategory { Id = 7, Name = " " }
				);
		}
	}
}
