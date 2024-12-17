using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Home;

namespace EliteAthleteApp.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UploadUserImageAsync(string userId, IFormFile imageFile);
        Task DeleteUserImageAsync(string userId);
        Task<HomeIndexVM> GetHomeIndexVMAsync();
    }
}
