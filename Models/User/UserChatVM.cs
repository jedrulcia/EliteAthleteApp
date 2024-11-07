﻿namespace EliteAthleteApp.Models.User
{
    public class UserChatVM
    {
        public int Id { get; set; }
        public List<UserChatMessageVM> UserChatMessageVMs { get; set; }
        public UserVM UserVM { get; set; }
        public UserVM CoachVM { get; set; }
        public string? ViewerId { get; set; }
    }
}
