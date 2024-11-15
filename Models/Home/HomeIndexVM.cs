using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Models.TrainingPlan;
using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.Home
{
	public class HomeIndexVM
	{
		public UserChartsVM? UserChartsVM { get; set; }
		public bool IsLoggedIn { get; set; } = false;
		public UserVM? UserVM { get; set; }
		public TrainingPlanDetailsVM? TrainingPlanDetailsVM { get; set; }
	}
}
