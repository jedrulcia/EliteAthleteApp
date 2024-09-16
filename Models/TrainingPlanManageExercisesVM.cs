using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
	public class TrainingPlanManageExercisesVM
	{
		// IDs
		public int? Id { get; set; }

		// FORMS
		public SelectList? AvailableExercises { get; set; }

        [Display(Name = "Exercise")]
        public int? NewExerciseId { get; set; }
        public int? NewExerciseWeight { get; set; }
        public int? NewExerciseSets { get; set; }
        public int? NewExerciseRepeats { get; set; }
        public string? NewExerciseIndex { get; set; }

        // LISTS
        public List<int?>? ExerciseIds { get; set; }
        public List<ExerciseVM?>? Exercises { get; set; }
        public List<int?>? Weight { get; set; }
		public List<int?>? Sets { get; set; }
		public List<int?>? Repeats { get; set; }
		public List<string?>? Index { get; set; }

		// OTHER
		public bool RedirectToAdmin { get; set; }
	}
}
