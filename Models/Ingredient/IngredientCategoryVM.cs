using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Ingredient
{
	public class IngredientCategoryVM
	{
		// IDs
		public int Id { get; set; }

		// STRINGS etc.
		[Display(Name = "Ingredient Category")]
		[Required]
		public string Name { get; set; }
	}
}
