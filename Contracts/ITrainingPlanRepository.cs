using TrainingPlanApp.Web.Data;
using TrainingPlanApp.Web.Models;

namespace TrainingPlanApp.Web.Contracts
{
    public interface ITrainingPlanRepository : IGenericRepository<TrainingPlan>
    {
        Task<List<TrainingPlanVM>> GetUserTrainingPlans(string userId);
        Task ChangeTrainingPlanStatus(int trainingPlanId, bool status);

	}
}
