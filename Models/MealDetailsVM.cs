using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Contracts;

namespace TrainingPlanApp.Web.Models
{
    public class MealDetailsVM : IMacroRepository
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Recipe")]
        public string? Recipe { get; set; }
        [Display(Name = "Amount of kcal")]
        public int? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public decimal Proteins { get; set; }
        [Display(Name = "Amount of fats")]
        public decimal Fats { get; set; }
        [Display(Name = "Amount of carbs")]
        public decimal Carbohydrates { get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<int>? IngredientQuantities { get; set; }
        [Display(Name = "Ingredient")]
        public List<IngredientVM?>? Ingredients { get; set; }
    }
}
