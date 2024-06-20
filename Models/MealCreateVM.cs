using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class MealCreateVM
    {
        public int? Id { get; set; }
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Display(Name = "Amount of kcal")]
        public int? Kcal { get; set; }
        [Display(Name = "Amount of proteins")]
        public int? Protein { get; set; }
        [Display(Name = "Amount of fats")]
        public int? Fat { get; set; }
        [Display(Name = "Amount of carbs")]
        public int? Carbs { get; set; }
        [Display(Name = "List of ingredients")]
        public List<IngredientVM>? Ingredients { get; set; }
        [Display(Name = "Ingredient")]
        public string? IngredientName { get; set; }
        [Display(Name = "Serving size (g)")]
        public int? IngredientServingSize {  get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }

    }
}
