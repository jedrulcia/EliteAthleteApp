namespace EliteAthleteApp.Models.Charts
{
	public class TrainingOrmChartVM
	{
		public List<DataPointVM> BenchPressDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> OverheadPressDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> DeadliftDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> SquatDataPointVMs { get; set; } = new List<DataPointVM?>();
	}
}
