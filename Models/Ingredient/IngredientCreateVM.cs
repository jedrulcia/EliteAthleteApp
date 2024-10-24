using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.Ingredient
{
	public class IngredientCreateVM
	{
		// IDs
		public int? Id { get; set; }
		public int? IngredientCategoryId { get; set; }
		public string? DieticianId { get; set; }

		// STRINGS etc.
		[Required]
		[Display(Name = "Name")]
		public string? Name { get; set; }

		// MACROS
		[Required]
		[Display(Name = "Proteins in 100g")]
		public decimal? Proteins { get; set; }

		[Required]
		[Display(Name = "Carbohydrates in 100g")]
		public decimal? Carbohydrates { get; set; }

		[Required]
		[Display(Name = "Fats in 100g")]
		public decimal? Fats { get; set; }

		[Display(Name = "Fibre in 100g")]
		public decimal? Fibres { get; set; }

		// NUMBERS
		[Display(Name = "Suggested Portion (g)")]
		public int? SuggestedPortion { get; set; }

		// FORM
		public SelectList? AvailableCategories { get; set; }
		
		// OTHER
		public bool SetAsPublic { get; set; }
		public string? Redirect {  get; set; }
	}
}
