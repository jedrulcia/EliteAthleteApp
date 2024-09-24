using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models.Ingredient
{
    public class IngredientVM
    {
        // IDs
        public int? Id { get; set; }

        // STRINGS etc.
        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        // MACROS
        [Display(Name = "Kcal in 100g")]
        public int? Kcal { get; set; }

        [Required]
        [Display(Name = "Protein in 100g")]
        public decimal Proteins { get; set; }

        [Required]
        [Display(Name = "Carbohydrates in 100g")]
        public decimal Carbohydrates { get; set; }

        [Required]
        [Display(Name = "Fats in 100g")]
        public decimal Fats { get; set; }
    }
}
