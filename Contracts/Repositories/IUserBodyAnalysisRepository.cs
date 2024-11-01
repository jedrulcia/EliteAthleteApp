using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserBodyAnalysis;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface IUserBodyAnalysisRepository : IGenericRepository<UserBodyAnalysis>
	{
		// GETS LIST OF USER BODY ANALYSIS
		Task<List<UserBodyAnalysisVM>> GetUserBodyAnalysisVMsAsync(string userId);

		// GETS USER BODY ANALYSIS CREATE VM
		UserBodyAnalysisCreateVM GetUserBodyAnalysisCreateVM(string userId);

		// GETS USER BODY ANALYSIS EDIT VIEW MODEL
		Task<UserBodyAnalysisCreateVM> GeUserBodyAnalysisEditVM(int bodyAnalysisId);

		// GETS USER BODY ANALYSIS DELETE VIEW MODEL
		Task<UserBodyAnalysisDeleteVM> GetUserBodyAnalysisDeleteVM(int bodyAnalysisId);

		// CREATES NEW USER BODY ANALYSIS ENTITY
		Task CreateUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM);

		// EDITS EXSITING USER BODY ANALYSIS ENTITY
		Task EditUserBodyAnalysisAsync(UserBodyAnalysisCreateVM userBodyAnalysisCreateVM);

		// DELETES USER BODY ANALYSIS ENTITY
		Task DeleteUserBodyAnalysisAsync(UserBodyAnalysisDeleteVM userBodyAnalysisDeleteVM);
	}
}
