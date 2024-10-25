using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingModule
{
	public class TrainingModuleORMCreateVM
	{
		public int? Id { get; set; }
		public string? UserId { get; set; }
		public int? BenchPressORM { get; set; }
		public int? OverheadPressORM { get; set; }
		public int? DeadliftORM { get; set; }
		public int? SquatORM { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }
	}
}
