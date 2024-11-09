using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyAnalysis
{
    public class UserBodyAnalysisCreateVM : IValidatableObject
	{
		// IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

		// URLs
		public string? FileUrl { get; set; }

		// DATES
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? CreationDate { get; set; }

		// NUMBERS
		public int? Weight { get; set; }
        public int? FatPercentage { get; set; }
        public int? MusclePercentage { get; set; }
        public int? WaterPercentage { get; set; }

		// VALIDATION
		public bool CreatedToday { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CreatedToday == true)
			{
				yield return new ValidationResult(
					"You have already created ORM today.",
					new[] { nameof(CreationDate) }
				);
			}
		}
	}
}
