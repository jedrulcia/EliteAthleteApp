using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Models.Ingredient;

namespace TrainingPlanApp.Web.Models.Meal
{
    public class MealDetailsVM
    {
        // IDs
        public int Id { get; set; }

        // STRINGS etc.
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Recipe")]
        public string? Recipe { get; set; }

        // MACROS
        public int? Kcal { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }

        // LISTS
        public List<int?>? IngredientIds { get; set; }
        public List<int>? IngredientQuantities { get; set; }
        public List<IngredientVM?>? Ingredients { get; set; }
    }
}
