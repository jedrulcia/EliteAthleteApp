using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserMedicalTest
{
    public class UserMedicalTestCreateVM : IValidatableObject
    {
		// IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

		// URLs
		public string? FileUrl { get; set; }

		// STRINGS
		[Required]
		public string? Name { get; set; }

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

		// VALIDATION
		public bool CreatedToday { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CreatedToday == true)
			{
				yield return new ValidationResult(
					"You have already created three User Medical Tests today.",
					new[] { nameof(CreationDate) }
				);
			}
		}
	}
}
