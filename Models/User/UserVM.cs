using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
    public class UserVM
    {
        // IDs
        public string Id { get; set; }
		public string? CoachId { get; set; }

        // URLs
		public string? ImageUrl { get; set; }

		// STRINGS

		[Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

		[Display(Name = "Date of Birth")]
		public string? DateOfBirth { get; set; }

		// OTHER

		public DateTimeOffset? LockoutEnd { get; set; }
    }
}
