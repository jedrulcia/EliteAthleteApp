using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		// IDs
		public int Id { get; set; }
		public int? IngredientCategoryId { get; set; }

		// STRINGS etc.
		public string? Name { get; set; }


		// MACROS
		public decimal? Proteins { get; set; }
		public decimal? Carbohydrates { get; set; }
		public decimal? Fats { get; set; }

		// NUMBERS
		public int? SuggestedPortion {  get; set; }
	}
}
