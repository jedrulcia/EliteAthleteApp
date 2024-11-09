using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingOrm
{
	public class TrainingOrmCreateVM : IValidatableObject
	{
		// IDs
		public int? Id { get; set; }
		public string? UserId { get; set; }

		// NUMBERS
		public int? BenchPressOrm { get; set; }
		public int? OverheadPressOrm { get; set; }
		public int? DeadliftOrm { get; set; }
		public int? SquatOrm { get; set; }

		// DATES

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }
		public DateTime? CreationDate { get; set; }

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
