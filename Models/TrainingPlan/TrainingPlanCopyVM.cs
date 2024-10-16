namespace TrainingPlanApp.Web.Models.TrainingPlan
{
	public class TrainingPlanCopyVM
	{
		public int? CopyFromId { get; set; }
		public int? TrainingModuleId { get; set; }
		public List<TrainingPlanVM?>? TrainingPlanVMs { get; set; }
	}
}
