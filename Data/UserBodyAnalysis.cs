﻿namespace EliteAthleteApp.Data
{
	public class UserBodyAnalysis
	{
		public int? Id { get; set; }
		public string? UserId { get; set; }
		public DateTime? DateTime { get; set; }
		public string? ImageUrl { get; set; }
		public int? Weight { get; set; }
		public int? FatPercentage {  get; set; }
		public int? MusclePercentage { get; set; }
		public int? WaterPercentage {  get; set; }
	}
}
