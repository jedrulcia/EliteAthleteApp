using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.TrainingOrm
{
    public class TrainingOrmVM
    {
        // IDs
        public int? Id { get; set; }
        public string? UserId { get; set; }

        //NUMBERS
        [Display(Name = "Bench Press")]
        public int? BenchPressOrm { get; set; }
        [Display(Name = "Overhead Press")]
        public int? OverheadPressOrm { get; set; }
        [Display(Name = "Deadlift")]
        public int? DeadliftOrm { get; set; }
        [Display(Name = "Squat")]
        public int? SquatOrm { get; set; }

        // DATES

        [DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime? DateTime { get; set; }
    }
}
