using EliteAthleteApp.Data;
using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
	public class UserAddAthleteVM : IValidatableObject
	{
		[Display(Name ="Invite Code")]
		public string? InviteCode { get; set; }
		public int? AthleteCount {  get; set; }
		public int? AthleteLimit { get; set; }
		public string? CoachId { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (AthleteCount >= AthleteLimit)
			{
				yield return new ValidationResult(
					"You have reached the limit of athletes.",
					new[] {nameof(AthleteCount)}
					);
			}
		}
	}
}
