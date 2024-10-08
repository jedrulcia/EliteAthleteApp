using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Ingredient
{
	public class IngredientVM
	{
		// IDs
		public int? Id { get; set; }
		public int? IngredientCategoryId { get; set; }
		public string? DieticianId { get; set; }

		// STRINGS etc.
		[Display(Name = "Name")]
		public string? Name { get; set; }

		// MACROS
		[Display(Name = "Kcal in 100g")]
		public int? Kcal { get; set; }

		[Display(Name = "Proteins in 100g")]
		public decimal Proteins { get; set; }

		[Display(Name = "Carbohydrates in 100g")]
		public decimal Carbohydrates { get; set; }

		[Display(Name = "Fats in 100g")]
		public decimal Fats { get; set; }

		[Display(Name = "Fibre in 100g")]
		public decimal Fibres { get; set; }

		// NUMBERS
		[Display(Name = "Suggested Portion (g)")]
		public int? SuggestedPortion { get; set; }

		// OTHER
		public IngredientCategoryVM? IngredientCategory { get; set; }
		public bool? SetAsPublic {  get; set; }
	}
}
