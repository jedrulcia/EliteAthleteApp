using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminUserVM
	{
		public string? AdminId { get; set; }
		public List<UserVM?> UserVMs { get; set; } = new List<UserVM?>();
	}
}
