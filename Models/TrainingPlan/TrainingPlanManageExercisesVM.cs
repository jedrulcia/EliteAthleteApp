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

		public TrainingPlanAddExerciseVM? TrainingPlanAddExerciseVM { get; set; }

		// LISTS
		// indices are used to get the order of exercises
		public List<string?>? Indices { get; set; }
		public List<ExerciseVM?>? Exercises { get; set; }
		public List<int?>? ExerciseIds { get; set; }
        public List<int?>? Sets { get; set; }
		// Units can be (example): 10reps/30sec/5km
		public List<string?>? Units { get; set; }
		public List<string?>? Weights { get; set; }
		public List<string?>? RestTimes { get; set; }
		public List<string?>? Notes { get; set; }
	}
}
