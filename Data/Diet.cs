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

	}
}
