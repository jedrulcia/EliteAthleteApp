﻿namespace TrainingPlanApp.Web.Data
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public List<int>? TrainingPlanIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
