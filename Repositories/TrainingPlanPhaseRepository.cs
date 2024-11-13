using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;

namespace EliteAthleteApp.Repositories
{
    public class TrainingPlanPhaseRepository : GenericRepository<TrainingPlanPhase>, ITrainingPlanPhaseRepository
	{
		private readonly ApplicationDbContext context;

		public TrainingPlanPhaseRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
