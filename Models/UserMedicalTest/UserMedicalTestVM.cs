using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserMedicalTest
{
    public class UserMedicalTestVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

		// URLs
		public string? FileUrl { get; set; }

		// STRINGS
		public string? Name { get; set; }

        // DATES
		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }
    }
}
