using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Models.Ingredient;

namespace EliteAthleteApp.Models.Meal
{
    public class MealManageIngredientsVM
    {
        // IDs
        public int? Id { get; set; }
        public string? DieticianId { get; set; }
		public int? MealCategoryId { get; set; }

		// STRINGS etc.
		public string? Name {  get; set; }
        public string? Recipe {  get; set; }

        // MACROS
        public int? Kcal { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public decimal Fibres {  get; set; }

        // FORM
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
		public List<decimal>? IngredientFibres { get; set; }
		public List<int?>? IngredientIds { get; set; }
        public List<IngredientVM?>? Ingredients { get; set; }

        // OTHER 
        public IngredientCreateVM? IngredientCreateVM { get; set; }
        public MealCreateVM? MealCreateVM { get; set; }
		public MealCategoryVM? MealCategory { get; set; }
		public string? ImageUrl { get; set; }
	}
}
