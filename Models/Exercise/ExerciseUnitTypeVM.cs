using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models.Exercise
{
	public class ExerciseUnitTypeVM
	{
		// IDs
		public int? Id { get; set; }

		// STRINGS etc.
		[Display(Name="Unit Type")]
		public string? Name { get; set; }
	}
}
