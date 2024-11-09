using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Data
{
	public class User : IdentityUser
	{
		// IDs
		public int? UserSubscriptionId { get; set; }
		public string? CoachId { get; set; }
		public string? NewCoachId { get; set; }

		// URLs
		public string? ImageUrl { get; set; }
		public string? InviteCode { get; set; }

		// STRINGS
		public string? FirstName {  get; set; }
		public string? LastName { get; set; }

		// DATES
		public DateTime? DateOfBirth { get; set; }
	}
}
