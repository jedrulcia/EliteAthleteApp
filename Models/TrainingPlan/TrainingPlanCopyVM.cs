namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanCopyVM
	{
		public int TrainingModuleId { get; set; }
		public int? CopyFromId { get; set; }
		public List<TrainingPlanVM?>? TrainingPlanVMs { get; set; }
	}
}
