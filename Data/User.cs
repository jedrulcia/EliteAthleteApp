using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Data
{
	public class User : IdentityUser
	{
		// STRINGS etc.
		public string? FirstName {  get; set; }
		public string? LastName { get; set; }
		public string? DateOfBith {  get; set; }
		public string? CoachId { get; set; }
		public string? DieticianId { get; set; }
	}
}
