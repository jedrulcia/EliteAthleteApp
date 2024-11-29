using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
	public class UserAddAthleteVM
	{
		[Display(Name ="Invite Code")]
		public string? InviteCode { get; set; }
		public int? AthleteCount {  get; set; }
	}
}
