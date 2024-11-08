using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.Admin
{
	public class AdminUserLockoutVM
	{
		public string AdminId { get; set; }
		public UserVM UserVM { get; set; }
		public DateTime LockoutDate { get; set; }
	}
}
