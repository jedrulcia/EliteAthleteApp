using EliteAthleteApp.Data;
using EliteAthleteApp.Models.Home;
using EliteAthleteApp.Models.User;
using EliteAthleteApp.Models.UserChat;

namespace EliteAthleteApp.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task UploadUserImageAsync(string userId, IFormFile imageFile);
        Task DeleteUserImageAsync(string userId);
        Task<HomeIndexVM> GetHomeIndexVMAsync();
        Task<UserIndexVM> GetUserIndexVMAsync(string? userId);
        Task<UserPanelVM> GetUserPanelVMAsync(string? userId);
        Task<List<UserVM>> GetUserListVMAsync();
        Task<UserAddAthleteVM> GetUserAddAthleteVMAsync(int athleteCount);
        Task AddAthleteAsync(UserAddAthleteVM userAddAthleteVM);
        Task<string> AcceptInviteAsync();
        Task<string> DeclineInviteAsync();
        Task<string> DeleteCoachAsync();
        Task<string> ResetInviteCodeAsync();
        Task<UserInfoVM> GetUserInfoVMAsync(string? userId);
        Task<AdminIndexVM> GetAdminIndexVMAsync();
        Task<AdminUserVM> GetAdminUserListVMAsync();
        Task<AdminSendEmailVM> GetAdminSendEmailVMAsync(string? userId);
        Task SendEmailAsync(AdminSendEmailVM adminSendEmailVM);
        Task<AdminUserDeleteVM> GetAdminUserDeleteVMAsync(string userId);
        Task UserDeleteAsync(UserVM userVM);
        Task<AdminUserLockoutVM> GetAdminUserLockoutVMAsync(string userId);
        Task UserLockoutAsync(AdminUserLockoutVM adminUserLockoutVM);
        Task<UserChatVM> GetUserChatVMAsync(string? userId);
    }
}
