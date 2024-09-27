namespace TrainingPlanApp.Web.Data
{
	public class Exercise
	{
		// IDs
		public int Id { get; set; }
		public int? ExerciseCategoryId { get; set; }

		// STRINGS etc.
		public string? Name { get; set; }
		public string? VideoLink { get; set; }
        public string? Description { get; set; }
	}
}
