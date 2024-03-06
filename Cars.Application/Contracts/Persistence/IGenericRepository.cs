
namespace Cars.Application.Contracts.Persistence
{
    /// <summary>
    /// This interface is used to mark the repository as a generic repository where T is the type of the entity
    /// and Generic Repository is used to define the common operations that can be performed on the entity
    /// </summary>
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<List<T>> GetAllAsync(string? includeProperties = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entities);
        Task DeleteAll(IEnumerable<T> entities);

    }
}
