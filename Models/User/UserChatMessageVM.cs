using System.ComponentModel.DataAnnotations;

namespace EliteAthleteApp.Models.User
{
    public class UserChatMessageVM
    {
		// IDs
        public string UserId { get; set; }

		// STRINGS
        public string Content { get; set; }

		// DATES
		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Timestamp { get; set; }
	}
}
