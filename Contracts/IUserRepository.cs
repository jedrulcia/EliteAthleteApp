using EliteAthleteApp.Data;

namespace EliteAthleteApp.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UploadUserImageAsync(string userId, IFormFile imageFile);
        Task DeleteUserImageAsync(string userId);
    }
}
