using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts.Repositories;

namespace EliteAthleteApp.Repositories
{
	public class ExerciseCategoryRepository : GenericRepository<ExerciseCategory>, IExerciseCategoryRepository
	{
		private readonly ApplicationDbContext context;

		public ExerciseCategoryRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
