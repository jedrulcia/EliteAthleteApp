using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminExerciseVM
	{
		// IDs
		public string? AdminId { get; set; }

		// LISTS
		public List<TrainingExerciseVM?> PrivateExerciseVMs { get; set; } = new List<TrainingExerciseVM?>();
	}
}
