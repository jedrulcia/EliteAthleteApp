using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Repositories
{
	public class TrainingExerciseMediaRepository : GenericRepository<TrainingExerciseMedia>, ITrainingExerciseMediaRepository
	{
		private readonly ApplicationDbContext context;

		public TrainingExerciseMediaRepository(ApplicationDbContext context) : base(context) 
		{
			this.context = context;
		}
	}
}
