using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Diet
	{
		// IDs
		public int Id { get; set; }
        public string? UserId { get; set; }
        public List<int?> MealIds { get; set; }

		// STRINGS etc.
		public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }

		// NUMBERS
		public List<int?> MealQuantities { get; set; }

		// OTHER
		public bool? IsActive { get; set; }
	}
}
