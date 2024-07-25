using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Kcal {  get; set; }
		public string? Proteins { get; set; }
		public string? Carbohydrates { get; set; }
		public string? Fats { get; set; }
	}
}
