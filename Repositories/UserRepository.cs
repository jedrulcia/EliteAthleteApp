using EliteAthleteApp.Data;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using EliteAthleteApp.Contracts;

namespace EliteAthleteApp.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IGoogleDriveService googleDriveService;

		public UserRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager, IGoogleDriveService googleDriveService) : base(context)
		{
			this.context = context;
			this.mapper = mapper;
			this.userManager = userManager;
			this.googleDriveService = googleDriveService;
		}
		// UPLOADS IMAGE TO AZURE BLOB STORAGE AND SAVES URL IN USER MEDIA ENTITY
		public async Task UploadUserImageAsync(string userId, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0)
			{
				var user = await userManager.FindByIdAsync(userId);
				user.ImageUrl = await googleDriveService.UploadUserImageAsync(imageFile);
				await UpdateAsync(user);
			}
		}

		// REMOVES IMAGE FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteUserImageAsync(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			await googleDriveService.RemoveFileAsync(user.ImageUrl);
			user.ImageUrl = null;
			await UpdateAsync(user);
		}
	}
}
