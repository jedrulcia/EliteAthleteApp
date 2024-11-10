namespace EliteAthleteApp.Data
{
	public class TrainingExercise
	{
		// IDs
		public int Id { get; set; }
		public int? ExerciseCategoryId { get; set; }
		public int? ExerciseMuscleGroupId { get; set; }
		public int? ExerciseMediaId { get; set; }
		public string? CoachId {  get; set; }

		// STRINGS
		public string? Name { get; set; }
        public string? Description { get; set; }
		public string? YoutubeLink { get; set; }

		// OTHER 
		public bool SetAsPublic { get; set; }
	}
}
