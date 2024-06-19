using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class MealCreateVM
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
        public int? Kcal { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbs { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? IngredientName { get; set; }
        public int? IngredientServingSize {  get; set; }

    }
}
