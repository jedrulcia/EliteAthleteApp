using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	public class IngredientUnitTypeSeedConfiguration : IEntityTypeConfiguration<IngredientUnitType>
	{
		public void Configure(EntityTypeBuilder<IngredientUnitType> builder)
		{
			builder.HasData(
				new IngredientUnitType { Id = 1, Name = "g" },
				new IngredientUnitType { Id = 2, Name = "portion" },
				new IngredientUnitType { Id = 3, Name = "ml" },
				new IngredientUnitType { Id = 4, Name = "piece" }
			);
		}
	}
}
