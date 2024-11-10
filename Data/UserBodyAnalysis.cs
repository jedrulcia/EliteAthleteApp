namespace EliteAthleteApp.Data
{
	public class UserBodyAnalysis
	{
		// IDs
		public int? Id { get; set; }
		public string? UserId { get; set; }

		// URLs
		public string? FileUrl { get; set; }

		// NUMBERS
		public int? Weight { get; set; }
		public int? FatPercentage {  get; set; }
		public int? MusclePercentage { get; set; }
		public int? WaterPercentage {  get; set; }

		// DATES
		public DateTime CreationDate { get; set; }
		public DateTime? DateTime { get; set; }
	}
}
