using TrainingPlanApp.Web.Models.TrainingPlan;

namespace TrainingPlanApp.Web.Models.TrainingModule
{
    public class TrainingModuleIndexVM
    {
        // IDs
        public int Id { get; set; }
        public string UserId { get; set; }

        // STRINGS etc.
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // LISTS
        public List<TrainingPlanIndexVM?>? TrainingPlans { get; set; }
        public List<int?>? TrainingPlanIds { get; set; }

        // OTHER
        public bool? IsActive { get; set; }
    }
}
