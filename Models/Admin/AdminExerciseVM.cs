using EliteAthleteApp.Models.TrainingExercise;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminExerciseVM
	{
		public string? AdminId { get; set; }
		public List<TrainingExerciseVM?> PrivateExerciseVMs { get; set; } = new List<TrainingExerciseVM?>();
	}
}
