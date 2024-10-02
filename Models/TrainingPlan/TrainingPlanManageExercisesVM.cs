using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models.Exercise;

namespace TrainingPlanApp.Web.Models.TrainingPlan
{
    public class TrainingPlanManageExercisesVM
    {
        // IDs
        public int? Id { get; set; }
		public int? TrainingModuleId { get; set; }
		public string? UserId { get; set; }
		public string? CoachId { get; set; }

		// FORMS
		public string? NewExerciseIndex { get; set; }
		public SelectList? AvailableExercises { get; set; }
		[Display(Name = "Exercise")]
		public int? NewExerciseId { get; set; }
		public float? NewExerciseWeight { get; set; }
		public int? NewExerciseSets { get; set; }
		public string? NewExerciseRestTime {  get; set; }
        public string? NewExerciseNote { get; set; }
		public string? NewExerciseRepeats { get; set; }
		public string? NewExerciseUnitType { get; set; }

		// LISTS
		public List<string?>? Indices { get; set; }
		public List<ExerciseVM?>? Exercises { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		// indices are used to get the order of exercises
		public List<float?>? Weights { get; set; }
        public List<int?>? Sets { get; set; }
		// repeats can be (example): 10reps/30sec/5km, unit types can be (example): reps/time/distance - these two fields are related
		public List<string?>? Repeats { get; set; }
		public List<string?>? UnitTypes { get; set; }
		public List<string?>? RestTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
