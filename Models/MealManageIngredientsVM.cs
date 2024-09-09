using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class MealManageIngredientsVM
	{
		public int? Id { get; set; }


		[Display(Name = "Ingredient")]
		public int? NewIngredientId { get; set; }
		[Display(Name = "Quantity (g)")]
		public int? NewIngredientQuantity { get; set; }

		[Display(Name = "Amount of kcal")]
		public int? Kcal { get; set; }
		[Display(Name = "Amount of proteins")]
		public decimal? Proteins { get; set; }
		[Display(Name = "Amount of fats")]
		public decimal? Fats { get; set; }
		[Display(Name = "Amount of carbs")]
		public decimal? Carbohydrates { get; set; }
		public SelectList? AvailableIngredients { get; set; }
		public List<int?>? IngredientIds { get; set; }
		[Display(Name = "Ingredient")]
		public List<IngredientVM?>? Ingredients { get; set; }
		[Display(Name = "Ingredient Quantity")]
		public List<int>? IngredientQuantities { get; set; }
		public List<decimal>? IngredientProteins { get; set; }
		public List<decimal>? IngredientFats { get; set; }
		public List<decimal>? IngredientCarbohydrates { get; set; }
		public List<int?>? IngredientKcal { get; set; }
		public bool RedirectToAdmin { get; set; }
	}
}
