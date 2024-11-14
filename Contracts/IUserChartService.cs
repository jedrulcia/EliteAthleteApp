using EliteAthleteApp.Models.Charts;
using EliteAthleteApp.Services;

namespace EliteAthleteApp.Contracts
{
	public interface IUserChartService
	{
		Task<UserChartsVM> GetUserCharts(string? userId);
	}
}
