using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserBodyAnalysis
{
    public class UserBodyAnalysisCreateVM
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTime { get; set; }
        public string? ImageUrl { get; set; }
        public int? Weight { get; set; }
        public int? FatPercentage { get; set; }
        public int? MusclePercentage { get; set; }
        public int? WaterPercentage { get; set; }
    }
}
