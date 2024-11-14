using EliteAthleteApp.Models.TrainingOrm;

namespace EliteAthleteApp.Models.TrainingOrm
{
	public class TrainingOrmListVM
	{
		public List<TrainingOrmVM?> TrainingOrmVMs {  get; set; } = new List<TrainingOrmVM?>();
		public List<DataPointVM> BenchPressDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> OverheadPressDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> DeadliftDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> SquatDataPointVMs { get; set; } = new List<DataPointVM?>();
	}
}
