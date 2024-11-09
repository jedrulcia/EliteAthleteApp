using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyMeasurements
{
    public class UserBodyMeasurementsCreateVM : IValidatableObject
    {
		// IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

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
		public int? Chest { get; set; }
        public int? Arms { get; set; }
        public int? Waist { get; set; }
        public int? Thighs { get; set; }
        public int? Hips { get; set; }

		// VALIDATION
		public bool CreatedToday { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CreatedToday == true)
			{
				yield return new ValidationResult(
					"You have already created UBM today.",
					new[] { nameof(CreationDate) }
				);
			}
		}
	}
}
