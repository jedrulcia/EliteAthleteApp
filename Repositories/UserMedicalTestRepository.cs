using EliteAthleteApp.Contracts.Repositories;
using EliteAthleteApp.Data;

namespace EliteAthleteApp.Repositories
{
	public class UserMedicalTestRepository : GenericRepository<UserMedicalTest>, IUserMedicalTestRepository
	{
		private readonly ApplicationDbContext context;

		public UserMedicalTestRepository(ApplicationDbContext context) : base(context)
		{
			this.context = context;
		}
	}
}
