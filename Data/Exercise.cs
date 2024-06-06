namespace TrainingPlanApp.Web.Data
{
	public class Exercise
	{
		public int Id { get; set; }
		public string? MainExerciseName { get; set; }
        public int? MainExerciseNumberOfRepeats { get; set; }
        public string? MainExerciseVideoLink { get; set; }
		public string? AdditionalExerciseName { get; set; }
        public int? AdditionalExerciseNumberOfRepeats { get; set; }
        public string? AdditionalExerciseVideoLink { get; set; }
        public int? OverallNumberOfSets { get; set; }
        public string? Description { get; set; }
	}
}
