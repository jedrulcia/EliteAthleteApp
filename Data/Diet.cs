using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Diet
	{
		public string Name { get; set; }
		public int Id { get; set; }
		public string? UserId { get; set; }
		public bool? IsActive { get; set; }
		public string? Description { get; set; }
		public DateTime? StartDate { get; set; }

		[ForeignKey("BreakfastId")]
		public Meal? Breakfast { get; set; }
		public int? BreakfastId { get; set; }

		[ForeignKey("SecondBreakfastId")]
		public Meal? SecondBreakfast { get; set; }
		public int? SecondBreakfastId { get; set; }

		[ForeignKey("LunchId")]
		public Meal? Lunch { get; set; }
		public int? LunchId { get; set; }

		[ForeignKey("SnackId")]
		public Meal? Snack { get; set; }
		public int? SnackId { get; set; }

		[ForeignKey("DinnerId")]
		public Meal? Dinner { get; set; }
		public int? DinnerId { get; set; }

	}
}
