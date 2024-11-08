namespace EliteAthleteApp.Models.Admin
{
	public class AdminSendEmailVM
	{
		public string? AdminId { get; set; }
		public string? UserId { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
