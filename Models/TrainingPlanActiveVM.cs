using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class TrainingPlanActiveVM
	{
		public int? Id { get; set; }
		[Display(Name = "Athlete")]
		public string? UserId { get; set; }
		[Display(Name = "Training Plan")]
		public string? Name { get; set; }
		[Display(Name = "Description")]
		public string? Description { get; set; }

		public List<TrainingPlanIndexVM>? ActiveTrainingPlans { get; set; }
		public List<ExerciseVM?>? Exercises { get; set; }
		public List<int?>? ExerciseIds { get; set; }

		[Display(Name = "Weight")]
		public List<int?>? Weight { get; set; }
		[Display(Name = "Sets")]
		public List<int?>? Sets { get; set; }
		[Display(Name = "Repeats")]
		public List<int?>? Repeats { get; set; }
		[Display(Name = "Exercise number")]
		public List<string?>? Index { get; set; }

	}
}
