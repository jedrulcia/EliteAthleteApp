using System.ComponentModel.DataAnnotations;

namespace TrainingPlanApp.Web.Models
{
    public class UserListVM
    {
        public string Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
		[Display(Name = "Last name")]
		public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set;}
    }
}
