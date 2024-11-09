using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingOrm
{
    public class TrainingOrmVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

        //NUMBERS
        public int? BenchPressOrm { get; set; }
        public int? OverheadPressOrm { get; set; }
        public int? DeadliftOrm { get; set; }
        public int? SquatOrm { get; set; }

        // DATES

		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }
    }
}
