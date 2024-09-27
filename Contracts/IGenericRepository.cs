namespace TrainingPlanApp.Web.Contracts
{
	public interface IGenericRepository<T> where T : class
	{
		// ADDS THE ENTITY TO THE DATABASE ASYNCHRONOUSLY.
		Task<T> AddAsync(T entity);

		// DELETES THE ENTITY FROM THE DATABASE ASYNCHRONOUSLY BASED ON THE SPECIFIED ID.
		Task DeleteAsync(int id);

		// CHECKS IF THE ENTITY EXISTS IN THE DATABASE BY ID.
		Task<bool> Exists(int id);

		// UPDATES THE ENTITY IN THE DATABASE ASYNCHRONOUSLY.
		Task UpdateAsync(T entity);

		// GETS THE ENTITY FROM THE DATABASE BY ID ASYNCHRONOUSLY.
		Task<T> GetAsync(int? id);

		// GETS ALL ENTITIES FROM THE DATABASE ASYNCHRONOUSLY.
		Task<List<T>> GetAllAsync();
	}
}
