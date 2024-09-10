using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal? Proteins { get; set; }
		public decimal? Carbohydrates { get; set; }
		public decimal? Fats { get; set; }
	}
}
