using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.Ingredient
{
    public class IngredientIndexVM
    {
        // IDs
        public int? Id { get; set; }
		public int? IngredientCategoryId { get; set; }

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

        // OTHER
        public IngredientCategoryVM? IngredientCategory { get; set; }
    }
}
