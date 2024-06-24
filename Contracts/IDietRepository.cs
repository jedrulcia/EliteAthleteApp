using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
	public interface IDietRepository : IGenericRepository<Diet>
	{
		Task CreateDiet(DietCreateVM dietCreateVM);
		Task ChangeDietStatus(int dietId, bool status);
		Task UpdateDiet(DietCreateVM dietCreateVM);

    }
}
