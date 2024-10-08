using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Configurations.Entities
{
	public class IngredientCategorySeedConfiguration : IEntityTypeConfiguration<IngredientCategory>
	{
		public void Configure(EntityTypeBuilder<IngredientCategory> builder)
		{
			builder.HasData(
				new IngredientCategory { Id = 1, Name = "Meats" },
				new IngredientCategory { Id = 2, Name = "Dairy" },
				new IngredientCategory { Id = 3, Name = "Vegetables" },
				new IngredientCategory { Id = 4, Name = "Fruits" },
				new IngredientCategory { Id = 5, Name = "Grains" },
				new IngredientCategory { Id = 6, Name = "Seafood" },
				new IngredientCategory { Id = 7, Name = "Fats and Oils" },
				new IngredientCategory { Id = 8, Name = "Nuts and Seeds" },
				new IngredientCategory { Id = 9, Name = " " }
			);
		}
	}
}
