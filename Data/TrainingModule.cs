using System.Collections.Specialized;

namespace EliteAthleteApp.Data
{
    public class TrainingModule
    {
        // IDs
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CoachId { get; set; }
		public List<int>? TrainingPlanIds { get; set; }

        // STRINGS
		public string Name { get; set; }
        public string? Description { get; set; }

        // DATES
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
