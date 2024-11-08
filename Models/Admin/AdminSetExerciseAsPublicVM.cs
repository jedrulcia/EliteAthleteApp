using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminSetExerciseAsPublicVM
	{
		public string AdminId { get; set; }
		public TrainingExerciseVM TrainingExerciseVM { get; set; }
	}
}
