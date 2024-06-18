using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Meal
	{
		public string? Name { get; set; }
		public int? Id { get; set; }
		public int? Kcal {  get; set; }
		public int? Protein { get; set; }
		public int? Fat { get; set; }
		public int? Carbs { get; set; }
	}
}
