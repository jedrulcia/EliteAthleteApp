namespace EliteAthleteApp.Models.Charts
{
	public class UserChartsVM
	{
		public TrainingOrmChartVM TrainingOrmChartVM { get; set; } = new TrainingOrmChartVM();
		public UserBodyAnalysisChartVM UserBodyAnalysisChartVM { get; set; } = new UserBodyAnalysisChartVM();
		public UserBodyMeasurementChartVM UserBodyMeasurementsChartVM { get; set; } = new UserBodyMeasurementChartVM();
	}
}
