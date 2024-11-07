using System.ComponentModel.DataAnnotations;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Models.TrainingExercise
{
    public class TrainingExerciseIndexVM
	{
		public string CoachId { get; set; }
        public int? ExerciseMediaId { get; set; }
        public int? PrivateExerciseCount { get; set; }
    }
}
