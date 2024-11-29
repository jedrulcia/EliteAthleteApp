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
		[Display(Name = "Weight")]
		public int? Weight { get; set; }
		[Display(Name = "Fat Percentage")]
		public int? FatPercentage { get; set; }
		[Display(Name = "Muscle Percentage")]
		public int? MusclePercentage { get; set; }
		[Display(Name = "Water Percentage")]
		public int? WaterPercentage { get; set; }

		// VALIDATION
		public bool CreatedToday { get; set; } = false;

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CreatedToday == true)
			{
				yield return new ValidationResult(
					"You have already created User Body Analysis today.",
					new[] { nameof(CreationDate) }
				);
			}
		}
	}
}
