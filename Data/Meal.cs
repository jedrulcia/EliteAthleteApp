using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Meal
	{
		public string? Name { get; set; }
		public int? Id { get; set; }
		public string? Description {  get; set; }
	}
}
