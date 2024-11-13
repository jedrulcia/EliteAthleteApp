using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts;

namespace EliteAthleteApp.Repositories
{
    public class TrainingExerciseMuscleGroupRepository : GenericRepository<TrainingExerciseMuscleGroup>, ITrainingExerciseMuscleGroupRepository
	{
		private readonly ApplicationDbContext context;

		public TrainingExerciseMuscleGroupRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
