using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL EXERCISE UNIT TYPES IN THE DATABASE. 
	public class ExerciseUnitTypeSeedConfiguration : IEntityTypeConfiguration<ExerciseUnitType>
	{
		public void Configure(EntityTypeBuilder<ExerciseUnitType> builder)
		{
			builder.HasData(
				new ExerciseUnitType { Id = 1, Name = "Reps" },
				new ExerciseUnitType { Id = 2, Name = "Time" },
				new ExerciseUnitType { Id = 3, Name = "Distance" }
				);
		}
	}
}
