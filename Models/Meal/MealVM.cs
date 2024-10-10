using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Meal
{
	public class MealVM
	{
		public int Id { get; set; }
		public List<int?>? IngredientIds { get; set; }
		public string? DieticianId { get; set; }
		public int? MealCategoryId { get; set; }

		//STRINGS etc.
		[Display(Name = "Name")]
		public string? Name { get; set; }
		public string? Recipe {  get; set; }

		// MACROS
		[Display(Name = "Kcal")]
		public int? Kcal { get; set; }
		public decimal Proteins { get; set; }
		public decimal Carbohydrates { get; set; }
		public decimal Fats { get; set; }
		public decimal Fibres { get; set; }

		// LISTS
		public List<int>? IngredientQuantities { get; set; }

		// OTHER
		public MealCategoryVM MealCategory { get; set; }
		public string? ImageUrl { get; set; }
	}
}
