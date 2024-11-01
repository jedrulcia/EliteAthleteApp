using EliteAthleteApp.Data;

namespace EliteAthleteApp.Contracts.Repositories
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task UploadImageAsync(string userId, IFormFile imageFile);
		Task DeleteImageAsync(string userId);
	}
}
