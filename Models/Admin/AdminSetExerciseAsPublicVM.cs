using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminSetExerciseAsPublicVM
	{
		// IDs
		public string AdminId { get; set; }

		// OBJECTS
		public TrainingExerciseVM TrainingExerciseVM { get; set; }
	}
}
