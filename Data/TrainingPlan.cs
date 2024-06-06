using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class TrainingPlan
	{
		public int Id { get; set; }
		[ForeignKey("ExerciseFirstId")]
		public Exercise? ExerciseFirst {  get; set; }
		public int? ExerciseFirstId { get; set; }
		[ForeignKey("ExerciseSecondId")]
		public Exercise? ExerciseSecond { get; set; }
		public int? ExerciseSecondId { get; set; }
		[ForeignKey("ExerciseThirdId")]
		public Exercise? ExerciseThird { get; set; }
		public int? ExerciseThirdId { get; set; }
		[ForeignKey("ExerciseFourthId")]
		public Exercise? ExerciseFourth { get; set; }
		public int? ExerciseFourthId { get; set; }
		public string? UserId { get; set; }
	}
}
