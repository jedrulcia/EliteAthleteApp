using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	public class ExerciseUnitSeedConfiguration : IEntityTypeConfiguration<ExerciseUnit>
	{
		public void Configure(EntityTypeBuilder<ExerciseUnit> builder)
		{
			builder.HasData(
				new ExerciseUnit { Id = 1, Name = "Reps" },
				new ExerciseUnit { Id = 2, Name = "Time" },
				new ExerciseUnit { Id = 3, Name = "Distance" }
				);
		}
	}
}
