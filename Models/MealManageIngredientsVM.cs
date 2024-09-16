using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Contracts;

namespace TrainingPlanApp.Web.Models
{
	public class MealManageIngredientsVM
	{
		// IDs
		public int? Id { get; set; }

		// MACROS
		public int? Kcal { get; set; }
		public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }

		// FORMS DATA
		public SelectList? AvailableIngredients { get; set; }

        [Display(Name = "Ingredient")]
        public int? NewIngredientId { get; set; }

        [Display(Name = "Quantity (g)")]
        public int? NewIngredientQuantity { get; set; }

        // LISTS
        [Display(Name = "Ingredient Quantity")]
		public List<int>? IngredientQuantities { get; set; }
        public List<int?>? IngredientKcal { get; set; }
        public List<decimal>? IngredientProteins { get; set; }
        public List<decimal>? IngredientCarbohydrates { get; set; }
        public List<decimal>? IngredientFats { get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<IngredientVM?>? Ingredients { get; set; }

        // OTHER
        public bool RedirectToAdmin { get; set; }
    }
}
