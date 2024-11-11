using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
	public class UserInfoVM
	{
		// IDs
		public string? InviteCode { get; set; }

		// URLS
		public string? ImageUrl { get; set; }

		// OBJECTS
		public UserVM? CoachVM { get; set; }
		public UserVM? NewCoachVM { get; set; }
		public UserVM? UserVM { get; set; }
	}
}
