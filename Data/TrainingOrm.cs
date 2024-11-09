using Microsoft.AspNetCore.Routing.Constraints;

namespace EliteAthleteApp.Data
{
	public class TrainingOrm
	{
		public int? Id { get; set; }
		public string? UserId { get; set; }
		public int? BenchPressOrm { get; set; }
		public int? OverheadPressOrm { get; set; }
		public int? DeadliftOrm { get; set; }
		public int? SquatOrm { get; set; }
		public DateTime DateTime { get; set; }
		public DateTime CreationDate {  get; set; }
	}
}
