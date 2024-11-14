namespace EliteAthleteApp.Models.TrainingPlan
{
	public class TrainingPlanCopyVM
	{
		// IDs
		public int TrainingModuleId { get; set; }
		public int? CopyFromId { get; set; }

		// OBJECTS
		public List<TrainingPlanVM?>? TrainingPlanVMs { get; set; }
	}
}
