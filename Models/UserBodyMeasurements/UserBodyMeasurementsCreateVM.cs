using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyMeasurements
{
    public class UserBodyMeasurementsCreateVM : IValidatableObject
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTime { get; set; }
        public int? Chest { get; set; }
        public int? Arms { get; set; }
        public int? Waist { get; set; }
        public int? Thighs { get; set; }
        public int? Hips { get; set; }
		public DateTime? CreationDate { get; set; }
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
