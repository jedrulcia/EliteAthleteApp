using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Repositories
{
	public class MealRepository : GenericRepository<Meal>, IMealRepository
	{
		public MealRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
