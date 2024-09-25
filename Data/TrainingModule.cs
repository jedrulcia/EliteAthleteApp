namespace TrainingPlanApp.Web.Data
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public List<TrainingPlan?>? TrainingPlans { get; set; }

    }
}
