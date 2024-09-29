using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Ingredient
{
	public class IngredientCreateVM
	{
		// IDs
		public int? Id { get; set; }
		public int? IngredientCategoryId { get; set; }

		// STRINGS etc.
		[Required]
		[Display(Name = "Name")]
		public string? Name { get; set; }

		// MACROS
		[Required]
		[Display(Name = "Proteins in 100g")]
		public decimal Proteins { get; set; }

		[Required]
		[Display(Name = "Carbohydrates in 100g")]
		public decimal Carbohydrates { get; set; }

		[Required]
		[Display(Name = "Fats in 100g")]
		public decimal Fats { get; set; }

		// NUMBERS
		[Display(Name = "Suggested Portion (g)")]
		public int? SuggestedPortion { get; set; }

		// FORM
		public SelectList? AvailableIngredientCategories { get; set; }
	}
}
