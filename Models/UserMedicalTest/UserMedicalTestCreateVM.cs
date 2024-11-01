using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.UserMedicalTest
{
    public class UserMedicalTestCreateVM
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTime { get; set; }
        public string? ImageUrl { get; set; }
    }
}
