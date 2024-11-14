namespace EliteAthleteApp.Models.TrainingExercise
{
	public class TrainingExerciseMediaVM
	{
		// IDs
		public int? Id { get; set; }

		// URLs
		public string? VideoUrl { get; set; }
		public List<string?>? ImageUrls { get; set; } = new List<string?>();
	}
}
