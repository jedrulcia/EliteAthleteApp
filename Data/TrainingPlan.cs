using System.ComponentModel.DataAnnotations.Schema;
using TrainingPlanApp.Web.Controllers;

namespace TrainingPlanApp.Web.Data
{
	public class TrainingPlan
    {
        public int? Id { get; set; }
        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public List<Exercise>? Exercises { get; set; }
	}
}
