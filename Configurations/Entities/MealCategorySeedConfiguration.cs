using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Configurations.Entities
{
	// SEED CONFIGURATION FOR INITIAL MEAL CATEGORIES IN THE DATABASE.
	public class MealCategorySeedConfiguration : IEntityTypeConfiguration<MealCategory>
	{
		public void Configure(EntityTypeBuilder<MealCategory> builder)
		{
			builder.HasData(
				new MealCategory { Id = 1, Name = " " },
				new MealCategory { Id = 2, Name = "Vegetarian" },
				new MealCategory { Id = 3, Name = "Vegan" },
				new MealCategory { Id = 4, Name = "Gluten-Free" },
				new MealCategory { Id = 5, Name = "Low-Calorie" },
				new MealCategory { Id = 6, Name = "High-Protein" },
				new MealCategory { Id = 7, Name = "Low-Carb" },
				new MealCategory { Id = 8, Name = "Paleo" },
				new MealCategory { Id = 9, Name = "Ketogenic" },
				new MealCategory { Id = 10, Name = "Dairy-Free" },
				new MealCategory { Id = 11, Name = "Sugar-Free" },
				new MealCategory { Id = 12, Name = "Raw" },
				new MealCategory { Id = 13, Name = "With Superfoods" },
				new MealCategory { Id = 14, Name = "Diet-Friendly" },
				new MealCategory { Id = 15, Name = "Functional" },
				new MealCategory { Id = 16, Name = "Allergen-Free" }
			);
		}
	}
}
