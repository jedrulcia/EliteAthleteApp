using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Models
{
    public class IngredientVM
	{
		public int? Id { get; set; }
		[Required]
		[Display (Name = "Name")]
		public string? Name { get; set; }
		[Required]
		[Display(Name = "Kcal in 100g")]
		public string? Kcal { get; set; }
		[Required]
		[Display(Name = "Protein in 100g")]
		public string? Proteins { get; set; }
		[Required]
		[Display(Name = "Carbohydrates in 100g")]
		public string? Carbohydrates { get; set; }
		[Required]
		[Display(Name = "Fats in 100g")]
		public string? Fats { get; set; }
	}
}
