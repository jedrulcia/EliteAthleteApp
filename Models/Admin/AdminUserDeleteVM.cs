using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminUserDeleteVM
	{
		// IDs
		public string AdminId { get; set; }

		// OBJECTS
		public UserVM UserVM { get; set; }
	}
}
