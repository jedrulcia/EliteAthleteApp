using EliteAthleteApp.Data;
using EliteAthleteApp.Models.UserBodyMeasurements;

namespace EliteAthleteApp.Contracts.Repositories
{
    public interface IUserBodyMeasurementsRepository : IGenericRepository<UserBodyMeasurements>
	{
		// GETS LIST OF USER BODY MEASUREMENTS
		Task<List<UserBodyMeasurementsVM>> GetUserBodyMeasurementsVMsAsync(string userId);

		// GETS USER BODY MEASUREMENTS CREATE VM
		UserBodyMeasurementsCreateVM GetUserBodyMeasurementCreateVM(string userId);

		// GETS USER BODY MEASUREMENTS EDIT VIEW MODEL
		Task<UserBodyMeasurementsCreateVM> GeUserBodyMeasurementEditVM(int bodyMeasurementId);

		// GETS USER BODY MEASUREMENTS DELETE VIEW MODEL
		Task<UserBodyMeasurementsDeleteVM> GetUserBodyMeasurementDeleteVM(int bodyMeasurementId);

		// CREATES NEW USER BODY MEASUREMENTS ENTITY
		Task CreateUserBodyMeasurementAsync(UserBodyMeasurementsCreateVM userBodyMeasurementCreateVM);

		// EDITS EXSITING USER BODY MEASUREMENTS ENTITY
		Task EditUserBodyMeasurementAsync(UserBodyMeasurementsCreateVM userBodyMeasurementCreateVM);

		// DELETES USER BODY MEASUREMENTS ENTITY
		Task DeleteUserBodyMeasurementAsync(UserBodyMeasurementsDeleteVM userBodyMeasurementDeleteVM);
	}
}
