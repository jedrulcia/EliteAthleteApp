using EliteAthleteApp.Data;
using EliteAthleteApp.Contracts.Repositories;
using AutoMapper;
using EliteAthleteApp.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly ApplicationDbContext context;
		private readonly IBlobStorageService blobStorageService;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;

		public UserRepository(ApplicationDbContext context, IBlobStorageService blobStorageService, IMapper mapper, UserManager<User> userManager) : base(context)
		{
			this.context = context;
			this.blobStorageService = blobStorageService;
			this.mapper = mapper;
			this.userManager = userManager;
		}
		// UPLOADS IMAGE TO AZURE BLOB STORAGE AND SAVES URL IN USER MEDIA ENTITY
		public async Task UploadUserImageAsync(string userId, IFormFile imageFile)
		{
			if (imageFile != null && imageFile.Length > 0)
			{
				var user = await userManager.FindByIdAsync(userId);
				user.ImageUrl = await blobStorageService.UploadUserImageAsync(imageFile);
				await UpdateAsync(user);
			}
		}

		// REMOVES IMAGE FROM AZURE BLOB STORAGE AND URL FROM EXERCISE MEDIA ENTITY
		public async Task DeleteUserImageAsync(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			await blobStorageService.RemoveExerciseImageAsync(user.ImageUrl);
			user.ImageUrl = null;
			await UpdateAsync(user);
		}
	}
}
