using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyAnalysis
{
    public class UserBodyAnalysisCreateVM : IValidatableObject
	{
        public int? Id { get; set; }
        public string? UserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTime { get; set; }
        public string? FileUrl { get; set; }
        public int? Weight { get; set; }
        public int? FatPercentage { get; set; }
        public int? MusclePercentage { get; set; }
        public int? WaterPercentage { get; set; }
		public DateTime? CreationDate { get; set; }
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
