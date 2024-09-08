using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class MealVM
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Amount of kcal")]
        public int? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public int? Proteins { get; set; }
        [Display(Name = "Amount of fats")]
        public int? Fats { get; set; }
        [Display(Name = "Amount of carbs")]
        public int? Carbohydrates { get; set; }
        public List<int?>? IngredientIds { get; set; }
        public List<int?>? IngredientQuantities { get; set; }
    }
}
