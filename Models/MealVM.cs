using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class MealVM
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Amount of kcal")]
        public double? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public double? Proteins { get; set; }
        [Display(Name = "Amount of fats")]
        public double? Fats { get; set; }
        [Display(Name = "Amount of carbs")]
        public double? Carbohydrates { get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<int?>? IngredientQuantities { get; set; }
    }
}
