namespace TrainingPlanApp.Web.Models.TrainingModule
{
    public class TrainingModuleCreateVM
    {
        // IDs
        public int Id { get; set; }
        public string UserId { get; set; }

        // STRINGS etc.
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
