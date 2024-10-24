using Microsoft.AspNetCore.Routing.Constraints;

namespace EliteAthleteApp.Data
{
	public class TrainingModuleORM
	{
		public int? Id { get; set; }
		public string? UserId { get; set; }
		public int? BenchPressORM { get; set; }
		public int? OverheadPressORM { get; set; }
		public int? DeadliftORM { get; set; }
		public int? SquatORM { get; set; }
		public DateTime DateTime { get; set; }
	}
}
