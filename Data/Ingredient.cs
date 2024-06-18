using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ServingSize { get; set; }

		[ForeignKey("MealId")]
		public Meal? Meal { get; set; }
		public int? MealId { get; set; }
	}
}
