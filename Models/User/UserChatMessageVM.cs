﻿namespace EliteAthleteApp.Models.User
{
    public class UserChatMessageVM
    {
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
    }
}