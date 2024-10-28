using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts.Repositories;

namespace EliteAthleteApp.Repositories
{
	public class TrainingExerciseCategoryRepository : GenericRepository<TrainingExerciseCategory>, ITrainingExerciseCategoryRepository
	{
		private readonly ApplicationDbContext context;

		public TrainingExerciseCategoryRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
