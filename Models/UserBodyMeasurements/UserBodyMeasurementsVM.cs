using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyMeasurements
{
    public class UserBodyMeasurementsVM
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
    }
}
