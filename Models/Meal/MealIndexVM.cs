using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Meal
{
    public class MealIndexVM
    {
        // IDs
        public int Id { get; set; }
		public List<int?>? IngredientIds { get; set; }

		//STRINGS etc.
		[Display(Name = "Name")]
        public string? Name { get; set; }

        // MACROS
        public int? Kcal { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public decimal? Fibres { get; set; }

        // LISTS
        public List<int>? IngredientQuantities { get; set; }
    }
}
