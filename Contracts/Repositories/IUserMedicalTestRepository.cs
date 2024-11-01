using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserMedicalTest;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface IUserMedicalTestRepository : IGenericRepository<UserMedicalTest>
	{
		// GETS LIST OF USER BODY ANALYSIS
		Task<List<UserMedicalTestVM>> GetUserMedicalTestVMsAsync(string userId);

		// GETS USER BODY ANALYSIS CREATE VM
		UserMedicalTestCreateVM GetUserMedicalTestCreateVM(string userId);

		// GETS USER BODY ANALYSIS EDIT VIEW MODEL
		Task<UserMedicalTestCreateVM> GeUserMedicalTestEditVM(int medicalTestId);

		// GETS USER BODY ANALYSIS DELETE VIEW MODEL
		Task<UserMedicalTestDeleteVM> GetUserMedicalTestDeleteVM(int medicalTestId);

		// CREATES NEW USER BODY ANALYSIS ENTITY
		Task CreateUserMedicalTestAsync(UserMedicalTestCreateVM userMedicalTestCreateVM);

		// EDITS EXSITING USER BODY ANALYSIS ENTITY
		Task EditUserMedicalTestAsync(UserMedicalTestCreateVM userMedicalTestCreateVM);

		// DELETES USER BODY ANALYSIS ENTITY
		Task DeleteUserMedicalTestAsync(UserMedicalTestDeleteVM userMedicalTestDeleteVM);
	}
}
