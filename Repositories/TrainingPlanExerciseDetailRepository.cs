using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Contracts;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Repositories
{
	public class TrainingPlanExerciseDetailRepository : GenericRepository<TrainingPlanExerciseDetail>, ITrainingPlanExerciseDetailRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly IExerciseRepository exerciseRepository;
		private readonly UserManager<User> userManager;
		private readonly IHttpContextAccessor httpContextAccessor;

		public TrainingPlanExerciseDetailRepository(ApplicationDbContext context,
			IMapper mapper,
			IExerciseRepository exerciseRepository,
			UserManager<User> userManager,
			IHttpContextAccessor httpContextAccessor) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.exerciseRepository = exerciseRepository;
			this.userManager = userManager;
			this.httpContextAccessor = httpContextAccessor;
		}


	}
}
