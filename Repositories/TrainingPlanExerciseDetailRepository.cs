using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Repositories
{
	public class TrainingPlanExerciseDetailRepository : GenericRepository<TrainingPlanExerciseDetail>, ITrainingPlanExerciseDetailRepository
	{
		private readonly ApplicationDbContext context;

		public TrainingPlanExerciseDetailRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
