using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyAnalysis
{
    public class UserBodyAnalysisVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

        // URLs
		public string? FileUrl { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }

        // NUMBERS
        public int? Weight { get; set; }
        public int? FatPercentage { get; set; }
        public int? MusclePercentage { get; set; }
        public int? WaterPercentage { get; set; }
    }
}
