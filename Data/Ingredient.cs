using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		// IDs
		public int Id { get; set; }

		// STRINGS etc.
		public string? Name { get; set; }

		// NUMBERS
		public decimal? Proteins { get; set; }
		public decimal? Carbohydrates { get; set; }
		public decimal? Fats { get; set; }
	}
}
