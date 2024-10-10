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
				new IngredientCategory { Id = 1, Name = " " },
				new IngredientCategory { Id = 2, Name = "Meats" },
				new IngredientCategory { Id = 3, Name = "Dairy" },
				new IngredientCategory { Id = 4, Name = "Vegetables" },
				new IngredientCategory { Id = 5, Name = "Fruits" },
				new IngredientCategory { Id = 6, Name = "Grains" },
				new IngredientCategory { Id = 7, Name = "Seafood" },
				new IngredientCategory { Id = 8, Name = "Fats and Oils" },
				new IngredientCategory { Id = 9, Name = "Nuts and Seeds" },
				new IngredientCategory { Id = 10, Name = "Herbs and Spices" },
				new IngredientCategory { Id = 11, Name = "Legumes" },
				new IngredientCategory { Id = 12, Name = "Baked Goods" },
				new IngredientCategory { Id = 13, Name = "Pasta and Noodles" },
				new IngredientCategory { Id = 14, Name = "Snacks" },
				new IngredientCategory { Id = 15, Name = "Sweets" }
			);
		}
	}
}
