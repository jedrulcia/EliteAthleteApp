using AutoMapper;
using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Contracts.Services;
using EliteAthleteApp.Data;
using Microsoft.AspNetCore.Identity;

namespace EliteAthleteApp.Repositories
{
	public class UserBodyAnalysisRepository : GenericRepository<UserBodyAnalysis>, IUserBodyAnalysisRepository
	{
		private readonly ApplicationDbContext context;

		public UserBodyAnalysisRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
