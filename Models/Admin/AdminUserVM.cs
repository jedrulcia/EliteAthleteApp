using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminUserVM
	{
		// IDs
		public string? AdminId { get; set; }

		// OBJECTS
		public List<UserVM?> UserVMs { get; set; } = new List<UserVM?>();
	}
}
