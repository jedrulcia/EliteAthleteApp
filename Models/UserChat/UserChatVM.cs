using EliteAthleteApp.Models.User;

namespace EliteAthleteApp.Models.UserChat
{
    public class UserChatVM
    {
        // IDs
        public int Id { get; set; }
        public string? ViewerId { get; set; }

        // OBJECTS
        public List<UserChatMessageVM> UserChatMessageVMs { get; set; } = new List<UserChatMessageVM>();
        public UserVM UserVM { get; set; }
        public UserVM CoachVM { get; set; }
    }
}
