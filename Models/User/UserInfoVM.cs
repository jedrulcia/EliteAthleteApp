using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
	public class UserInfoVM
	{
		// IDs
		public string? Id { get; set; }
		public string? InviteCode { get; set; }

		// URLS
		public string? ImageUrl { get; set; }

		// OBJECTS
		public UserVM? CoachVM { get; set; }
		public UserVM? NewCoachVM { get; set; }


		// STRINGS

		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		public string? DateOfBirth { get; set; }
	}
}
