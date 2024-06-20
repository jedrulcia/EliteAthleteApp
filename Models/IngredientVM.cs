using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class IngredientVM
    {
        public int? Id { get; set; }
        public int? MealId { get; set; }
        [Display(Name = "Ingredient")]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Serving size (g)")]
        [Required]
        public int? ServingSize { get; set; }
    }
}
