using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
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
        public string Email { get; set;}
    }
}
