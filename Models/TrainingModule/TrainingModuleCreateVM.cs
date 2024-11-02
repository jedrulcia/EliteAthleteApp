using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingModule
{
    public class TrainingModuleCreateVM : IValidatableObject
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }
		public string CoachId {  get; set; }

        // STRINGS etc.
        [Display(Name="Training Module")]
        [Required]
        public string Name { get; set; }

		[Display(Name = "Starting Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime StartDate { get; set; }

		[Display(Name = "Ending Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		[Required]
		public DateTime EndDate { get; set; }


		[Display(Name = "Ending Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		[DataType(DataType.Date)]
		public DateTime? LatestEndDate { get; set; }


		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (StartDate > EndDate)
			{
				yield return new ValidationResult(
					"The starting date must be earlier than the ending date.",
					new[] { nameof(StartDate), nameof(EndDate) }
				);
			}

			TimeSpan duration = EndDate.Subtract(StartDate);
			int numberOfDays = (int)duration.TotalDays;
			if (numberOfDays > 93)
			{
				yield return new ValidationResult(
					"Training Module cannot be longer than 3 months.",
					new[] { nameof(StartDate), nameof(EndDate) }
				);
			}

			DateTime today = DateTime.Today;
			DateTime twoWeeksBefore = today.AddDays(-14);
			DateTime twooWeeksAfter = today.AddDays(14);
			if (StartDate < twoWeeksBefore || StartDate > twooWeeksAfter)
			{
				yield return new ValidationResult(
					"New Training Module can be only created 2 weeks in advance or in the past.",
					new[] { nameof(StartDate), nameof(EndDate) }
				);
			}

			if (StartDate <= LatestEndDate)
			{
				yield return new ValidationResult(
					"An exsisting Training Module didn't end before selected date.",
					new[] { nameof(StartDate), nameof(EndDate) }
				);
			}
		}
	}
}
