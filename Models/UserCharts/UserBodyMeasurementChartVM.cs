using EliteAthleteApp.Models.UserCharts;

namespace EliteAthleteApp.Models.Charts
{
    public class UserBodyMeasurementChartVM
	{
		public List<DataPointVM> ChestDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> ArmsDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> WaistDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> ThighsDataPointVMs { get; set; } = new List<DataPointVM?>();
		public List<DataPointVM> HipsDataPointVMs { get; set; } = new List<DataPointVM?>();
	}
}
