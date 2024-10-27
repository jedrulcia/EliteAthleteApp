using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts.Repositories;

namespace EliteAthleteApp.Repositories
{
	public class ExerciseMuscleGroupRepository : GenericRepository<ExerciseMuscleGroup>, IExerciseMuscleGroupRepository
	{
		private readonly ApplicationDbContext context;

		public ExerciseMuscleGroupRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
