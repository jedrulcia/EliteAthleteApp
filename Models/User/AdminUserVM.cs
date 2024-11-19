namespace EliteAthleteApp.Models.User
{
    public class AdminUserVM
    {
        // IDs
        public string? AdminId { get; set; }

        // OBJECTS
        public List<UserVM?> UserVMs { get; set; } = new List<UserVM?>();
    }
}
