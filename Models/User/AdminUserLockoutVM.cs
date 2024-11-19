using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
    public class AdminUserLockoutVM
    {
        // IDs
        public string AdminId { get; set; }

        // OBJECTS
        public UserVM UserVM { get; set; }

        // DATES

        [Display(Name = "Lockout Date")]
        public DateTime LockoutDate { get; set; }
    }
}
