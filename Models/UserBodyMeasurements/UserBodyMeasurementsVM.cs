using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyMeasurements
{
    public class UserBodyMeasurementsVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

        // DATES

		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }

        // NUMBERS
        public int? Chest { get; set; }
        public int? Arms { get; set; }
        public int? Waist { get; set; }
        public int? Thighs { get; set; }
        public int? Hips { get; set; }
    }
}
