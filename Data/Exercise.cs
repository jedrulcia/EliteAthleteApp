namespace TrainingPlanApp.Web.Data
{
	public class Exercise
	{
		public int Id { get; set; }
		public int? ExerciseCategoryId { get; set; }
		public string? Name { get; set; }
		public string? VideoLink { get; set; }
        public string? Description { get; set; }
	}
}
