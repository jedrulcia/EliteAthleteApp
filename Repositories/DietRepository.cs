using TrainingPlanApp.Web.Contracts;
using TrainingPlanApp.Web.Data;

namespace TrainingPlanApp.Web.Repositories
{
	public class DietRepository : GenericRepository<Diet>, IDietRepository
	{
		public DietRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
