using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.TrainingExercise
{
    public class TrainingExerciseIndexVM
	{
        // IDs
		public string CoachId { get; set; }
        public int? ExerciseMediaId { get; set; }

        // VALIDATION
        public int? PrivateExerciseCount { get; set; }
    }
}
