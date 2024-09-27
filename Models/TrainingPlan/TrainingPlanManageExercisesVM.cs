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

        // FORMS
        public SelectList? AvailableExercises { get; set; }
		[Display(Name = "Exercise")]
		public int? NewExerciseId { get; set; }
		public SelectList? AvailableExerciseUnitTypes { get; set; }
        [Display(Name = "Exercise Unit")]
        public int? NewExerciseUnitTypeId { get; set; }
        public int? NewExerciseWeight { get; set; }
        public int? NewExerciseSets { get; set; }
        public int? NewExerciseUnitAmount { get; set; }
        public string? NewExerciseIndex { get; set; }
        public string? NewExerciseUnit { get; set; }
        public int? NewExerciseBreakTime {  get; set; }
        public string? NewExerciseNote { get; set; }

        // LISTS
        public List<ExerciseIndexVM?>? Exercises { get; set; }
        public List<ExerciseUnitType?>? ExerciseUnitTypes { get; set; }
		public List<string?>? Index { get; set; }
		public List<int?>? ExerciseIds { get; set; }
		public List<int?>? Weight { get; set; }
        public List<int?>? Sets { get; set; }
		public List<int?>? UnitAmounts { get; set; }
		public List<string?>? Units { get; set; }
		public List<int?>? ExerciseUnitTypeIds { get; set; }
		public List<int?>? BreakTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
