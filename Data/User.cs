using Microsoft.AspNetCore.Identity;

namespace TrainingPlanApp.Web.Data
{
	public class User : IdentityUser
	{
		public string? FirstName {  get; set; }
		public string? LastName { get; set; }
		public string? DateOfBith {  get; set; }
	}
}
