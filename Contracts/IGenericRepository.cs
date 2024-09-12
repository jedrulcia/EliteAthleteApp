namespace TrainingPlanApp.Web.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        // Adds the entity to database
        Task<T> AddAsync(T entity);

        // Deletes the entity from database
        Task DeleteAsync(int id);

        // Checks if entity exists in the database
        Task<bool> Exists(int id);

        // Updates the entity in database
        Task UpdateAsync(T entity);

        // Gets the entity from database
        Task<T> GetAsync(int? id);

        // Gets all entities from database
        Task<List<T>> GetAllAsync();
    }
}
