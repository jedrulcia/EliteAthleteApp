using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingPlanApp.Web.Data
{
	public class Diet
	{
		public int Id { get; set; }
        public string? UserId { get; set; }
        public List<int?> MealIds { get; set; }
		public List<int> MealQuantities { get; set; }
		public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
	}
}
