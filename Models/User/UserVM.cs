using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
    public class UserVM
    {
        // IDs
        public string Id { get; set; }

        // STRINGS etc.
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string? CoachId { get; set; }
    }
}
