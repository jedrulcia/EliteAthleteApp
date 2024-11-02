using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Data
{
	public class User : IdentityUser
	{
		// STRINGS etc.
		public string? FirstName {  get; set; }
		public string? LastName { get; set; }
		public string? DateOfBirth {  get; set; }
		public string? CoachId { get; set; }
		public string? ImageUrl { get; set; }
		public string? InviteCode { get; set; }
		public string? NewCoachId { get; set; }
	}
}
