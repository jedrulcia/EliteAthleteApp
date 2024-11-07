using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserMedicalTest
{
    public class UserMedicalTestCreateVM : IValidatableObject
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTime { get; set; }
        public string? FileUrl { get; set; }
		public DateTime? CreationDate { get; set; }
		public bool CreatedToday { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (CreatedToday == true)
			{
				yield return new ValidationResult(
					"You have already created UMT today.",
					new[] { nameof(CreationDate) }
				);
			}
		}
	}
}
