using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
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
