namespace EliteAthleteApp.Data
{
	public class UserBodyMeasurements
	{
		// IDs
		public int? Id { get; set; }
		public string? UserId { get; set; }

		// NUMBERS
		public int? Chest {  get; set; }
		public int? Arms {  get; set; }
		public int? Waist { get; set; }
		public int? Thighs { get; set; }
		public int? Hips { get; set; }

		// DATES
		public DateTime CreationDate { get; set; }
		public DateTime? DateTime { get; set; }
	}
}
